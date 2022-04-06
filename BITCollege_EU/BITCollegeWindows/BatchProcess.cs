using BITCollege_EU.Data;
using BITCollege_EU.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Utility;

namespace BITCollegeWindows
{
    public class BatchProcess
    {
        private BITCollege_EUContext db = new BITCollege_EUContext();
        private BITCollegeServiceReference.CollegeRegistrationClient service = new BITCollegeServiceReference.CollegeRegistrationClient();
        private string inputFileName ="";
        private string logFileName = "";
        private string logData = "";
        
        /// <summary>
        /// Obtains the difference between the passed collections and populates LOG error file.
        /// </summary>
        /// <param name="beforeQuery"></param>
        /// <param name="afterQuery"></param>
        /// <param name="message"></param>
        private void ProcessErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, string message) {
            //Obtaining differences
            IEnumerable<XElement> resultDiferences = beforeQuery.Except(afterQuery);
            foreach (XElement resultDifference in resultDiferences) {
                logData += "\n---------ERROR---------";
                logData += "\n File: " + inputFileName;
                logData += "\n Program: " + resultDifference.Element("program");
                logData += "\n Student Number: " + resultDifference.Element("student_no");
                logData += "\n Course Number: " + resultDifference.Element("course_no");
                logData += "\n Registration Number: " + resultDifference.Element("registration_no");
                logData += "\n Type: " + resultDifference.Element("type");
                logData += "\n Grade: " + resultDifference.Element("grade");
                logData += "\n Notes: " + resultDifference.Element("notes");
                logData += "\n Nodes: " + resultDifference.Nodes().Count();
                logData += "\n "+message;
                logData += "\n -----------------------";
            }
        }

        /// <summary>
        /// Function which process the Header details of the XML input file.
        /// </summary>
        private void ProcessHeader() {
            XDocument xDocument = XDocument.Load(inputFileName);

            //Validations
            if (xDocument.Element("student_update").Attributes().Count() != 3)
            {
                throw new BatchProcessException("EXCEPTION: Incorrect Amount of attributes");
            }   
            else if (xDocument.Element("student_update").Attribute("date").Value != DateTime.Now.ToString("yyyy-MM-dd"))
            {
                throw new BatchProcessException("EXCEPTION: Attribute DATE is incorrect");
            }
            else if (getAcademicPrograms(xDocument.Element("student_update").Attribute("program").Value) == null)
            {
                throw new BatchProcessException("EXCEPTION: Academic program acronym attribute does not exist in the datatabse");
            }
            else if (int.Parse(xDocument.Element("student_update").Attribute("checksum").Value) != calculateCheckSumFromFile(xDocument)) 
            {
                throw new BatchProcessException("EXCEPTION: Checksum attribute is incorrect");
            }
         }

        /// <summary>
        /// Function which process the Header detail of the XML input file.
        /// </summary>
        private void ProcessDetails(){
            XDocument xInputFile= XDocument.Load(inputFileName);
            string programAcronymFromRoot = xInputFile.Root.Attribute("program").Value;

            IEnumerable <XElement> xInputFileElements = xInputFile.Descendants("transaction");

            //Validations - Transaction has 7 child nodes each
            IEnumerable<XElement> transactionWithSevenChildNodes = xInputFileElements.
                    Where(transaction => transaction.Nodes().Count() == 7);
            // Calling the process error method 
            ProcessErrors(xInputFileElements, transactionWithSevenChildNodes, "Incorrect amount of nodes on Input Files");

            //Validations - Program
            IEnumerable<XElement> transactionWithValidPrograms = transactionWithSevenChildNodes.
                    Where(programElement => programElement.Element("program").Value == programAcronymFromRoot);
            // Calling the process error method 
            ProcessErrors(transactionWithSevenChildNodes, transactionWithValidPrograms, "Incorrect program acronym in transaction element");

            //Validations - Type
            IEnumerable<XElement> transactionWithValidTypes = transactionWithValidPrograms.
                    Where(typeElements=> Utility.Numeric.IsNumeric(typeElements.Element("type").Value, System.Globalization.NumberStyles.Integer) == true);
            // Calling the process error method 
            ProcessErrors(transactionWithValidPrograms, transactionWithValidTypes, "Type in transaction element is not a number");

            //Validations - Grade 
            IEnumerable<XElement> transactionWithValidGradesValues = transactionWithValidTypes.
                    Where(gradeElements => (Utility.Numeric.IsNumeric(gradeElements.Element("grade").Value, System.Globalization.NumberStyles.Float) == true) || gradeElements.Element("grade").Value.Equals("*"));
            // Calling the process error method 
            ProcessErrors(transactionWithValidTypes, transactionWithValidGradesValues, "Incorrect grade in transaction - Grade is not a number or it is not <*>");

            //Validations - must have type value of 1 or 2;
            IEnumerable<XElement> transactionValidTypesValues = transactionWithValidGradesValues.
                    Where(validTypeElements => (validTypeElements.Element("type").Value.Equals("1")) || (validTypeElements.Element("type").Value.Equals("2")));
            // Calling the process error method 
            ProcessErrors(transactionWithValidGradesValues, transactionValidTypesValues, "Incorrect Type in transaction element,  it is not 1 or 2");

            //Validations - If (Type = 1 => Grade = *) || if (Type = 2 => Grade >= 0 AND Grade <= 100 AND its a number)
            IEnumerable<XElement> transactionValidTypesAndGradesFiltered = transactionValidTypesValues.
                    Where(validGradeElements => 
                        (
                            ((validGradeElements.Element("type").Value == "1") && (validGradeElements.Element("grade").Value == "*"))
                            || 
                            ((validGradeElements.Element("type").Value == "2") && (
                                        (Utility.Numeric.IsNumeric(validGradeElements.Element("grade").Value, System.Globalization.NumberStyles.Float)) && 
                                        (double.Parse(validGradeElements.Element("grade").Value) >= 0) && 
                                        (double.Parse(validGradeElements.Element("grade").Value) <= 100)
                                ))
                            )
                         );
            // Calling the process error method 
            ProcessErrors(transactionValidTypesValues, transactionValidTypesAndGradesFiltered, "Grades does not correspond to the type of operation OR the grade is out of range [0 - 100]");

            //Validations - Student_no
            IEnumerable<long> studentNumberList = getStudentsNumbers();
            IEnumerable<XElement> transactionStudentNroFiltered = transactionValidTypesAndGradesFiltered.
                    Where(studentNros => studentNumberList.Contains(long.Parse(studentNros.Element("student_no").Value)) == true);
            // Calling the process error method 
            ProcessErrors(transactionValidTypesAndGradesFiltered, transactionStudentNroFiltered, "Student number does not exist in the database");

            //Validations - Course_no should be * if type = 2 || must exist within the db
            IEnumerable<string> courseNumberList = getCourseNumbers();
            IEnumerable<XElement> transactionCourseNroFiltered = transactionStudentNroFiltered.
                    Where(courseNros => 
                        (courseNros.Element("course_no").Value == "*" && courseNros.Element("type").Value == "2") 
                        ||
                        (courseNumberList.Contains(courseNros.Element("course_no").Value) == true)
                     );
            // Calling the process error method 
            ProcessErrors(transactionStudentNroFiltered, transactionCourseNroFiltered, "Curse number does not correspond to operation type <2> OR does not exist within the database");

            //Validations - registration_no
            IEnumerable<long> registrationNumbersList = getRegistrationNumbers();
            IEnumerable<XElement> transactionRegistrationNroFiltered = transactionCourseNroFiltered.
                    Where(registrationNros =>
                        (registrationNros.Element("registration_no").Value == "*" && registrationNros.Element("type").Value == "1")
                        ||
                        //(registrationNumbersList.Contains(long.Parse(registrationNros.Element("registration_no").Value)) == true)
                        (registrationNumbersList.Contains(
                            registrationNros.Element("registration_no").Value == "*" ? 0: long.Parse(registrationNros.Element("registration_no").Value)
                            ) == true)
                    );
            // Calling the process error method 
            ProcessErrors(transactionCourseNroFiltered, transactionRegistrationNroFiltered, "Registration number does not correspond to operation type<1> OR does not exist within the database");

            //Calling the Process Transactions
            ProcessTransactions(transactionRegistrationNroFiltered);
        }

        /// <summary>
        /// Process each transaction from a filtered dataSet and executes the required operations
        /// </summary>
        /// <param name="transactionRecords"></param>
        private void ProcessTransactions(IEnumerable<XElement> transactionRecords) {
            int serviceOutput = 0;
            Course courseOnDataSet;
            Student studentOnDataSet;
            foreach (XElement transactionRecord in transactionRecords) {
                string elementType = transactionRecord.Element("type").Value;
                switch (elementType)
                { 
                    case "1": //Indicates Registration
                        courseOnDataSet = getCourse(transactionRecord.Element("course_no").Value);
                        studentOnDataSet = getStudent(long.Parse(transactionRecord.Element("student_no").Value));

                        serviceOutput = service.RegisterCourse(studentOnDataSet.StudentId,
                                courseOnDataSet.CourdeId,
                                transactionRecord.Element("notes").Value);
                        if (serviceOutput == 0)
                        {
                            logData += "\n Sucessful Registration student " + transactionRecord.Element("student_no").Value +
                                " course " + courseOnDataSet.CourseNumber;
                        }
                        else 
                        {
                            logData += "\n ERROR: " + Utility.BusinessRules.RegisterError(serviceOutput);
                        }
                        break;

                    case "2": //Indicates Grading
                        serviceOutput = (int)service.UpdateGrade((double.Parse(transactionRecord.Element("grade").Value)*0.01),
                                getRegistration(int.Parse(transactionRecord.Element("registration_no").Value)).RegistrationId,
                                transactionRecord.Element("notes").Value);
                        
                        if (serviceOutput >= 0)
                        {
                            logData += "\n grade " + transactionRecord.Element("grade").Value +
                                    " applied to student " + transactionRecord.Element("student_no").Value +
                                    " for registration " + transactionRecord.Element("registration_no").Value;
                        }
                        else 
                        {
                            logData += "\n ERROR: " + Utility.BusinessRules.RegisterError(serviceOutput);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Process the writting of the logData into the logDataFile
        /// </summary>
        /// <returns></returns>
        public string WriteLogData() {
            StreamWriter writerLog = new StreamWriter(logFileName, true);
            string capturedLogData = "";
            if (File.Exists("COMPLETE -" + inputFileName))
            {
                File.Delete("COMPLETE - " + inputFileName);
            }
            else 
            {
                if (File.Exists(inputFileName)) 
                {
                    File.Move(inputFileName, "COMPLETE-" + inputFileName);
                }
                writerLog.Write(logData);
                writerLog.Close();
                capturedLogData = logData;
                logData = "";
            }
            return capturedLogData;
        }

        /// <summary>
        /// Test method
        /// </summary>
        public void encrypFileInput(string programAcronym, string key) {
            //Generating the appropiate files
            inputFileName = generateFileName(programAcronym) + ".xml";

            // Assignment 09
            string encryptedFileName = inputFileName + ".encrypted";
            Encryption.Encrypt(inputFileName, encryptedFileName, key);
        }

        /// <summary>
        /// Method which handles the processing of the entire input file.
        /// </summary>
        /// <param name="programAcronym"></param>
        /// <param name="key"></param>
        public void ProcessTransmission(string programAcronym, string key) {

            //Generating the appropiate files
            inputFileName = generateFileName(programAcronym) + ".xml";
            logFileName = "LOG " + generateFileName(programAcronym) + ".txt";

            // Assignment 09
            string encryptedFileName = inputFileName+".encrypted";

            // Checking if the file exists
            try
            {
                if (File.Exists(encryptedFileName))
                {
                    Encryption.Decrypt(inputFileName, encryptedFileName, key);
                    if (File.Exists(inputFileName))
                    {
                        ProcessHeader();
                        ProcessDetails();
                    }
                    else
                    {
                        //Addding a message to the logData string.
                        logData += "\n The file " + inputFileName + " does not exist";
                    }
                }
                else
                {
                    logData += "\n ERROR message: The encryption file does not exist "+encryptedFileName;
                }
            }
            catch (Exception exception)
            {
                logData += "\n ERROR message:  " + exception.Message;
            }

            /*
            // Checking if the file exists
            if (File.Exists(inputFileName))
            {
                try
                {
                    ProcessHeader();
                    ProcessDetails();
                }
                catch (Exception exception)
                {
                    logData += "\n ERROR message:  " + exception.Message;
                }
            }
            */
        }


        /// <summary>
        /// Generates a valid input file name based on dates and acronyms
        /// </summary>
        /// <param name="programAcronym"></param>
        /// <returns>Returns a valid input file name string</returns>
        private string generateFileName(string programAcronym) {
            return (DateTime.Today.Year + "-" + DateTime.Today.DayOfYear + "-" + programAcronym);
        }

        /// <summary>
        /// Gets and academicprogram object from the database based on a programAcronym
        /// </summary>
        /// <param name="programAcronym"></param>
        /// <returns>Returns an AcademicProgram object</returns>
        private AcademicProgram getAcademicPrograms(string programAcronym)
        {
            return db.AcademicPrograms.Where(x => x.ProgramAcronym == programAcronym).SingleOrDefault();
        }

        /// <summary>
        /// Gets a Course object based on its courseNumber
        /// </summary>
        /// <param name="courseNumber"></param>
        /// <returns>Returns a Course object</returns>
        private Course getCourse(string courseNumber)
        {
            return db.Courses.Where(x => x.CourseNumber == courseNumber).SingleOrDefault();
        }

        /// <summary>
        /// Gets a Student object based on its student Number
        /// </summary>
        /// <param name="courseNumber"></param>
        /// <returns>Returns a Student object</returns>
        private Student getStudent(long studentNumber)
        {
            return db.Students.Where(x => x.StudentNumber == studentNumber).SingleOrDefault();
        }

        /// <summary>
        /// Gets a Registration object based on its registrationNumber
        /// </summary>
        /// <param name="registrationNumber"></param>
        /// <returns>Returns a Registration object</returns>
        private Registration getRegistration(int registrationNumber)
        {
            return db.Registrations.Where(x => x.RegistrationNumber == registrationNumber).SingleOrDefault();
        }

        /// <summary>
        /// Gets a list of all studentNumbers from the database
        /// </summary>
        /// <returns>Returns an IEnumeable<long> of studentNumbers</returns>
        private IEnumerable<long> getStudentsNumbers()
        {
            return db.Students.Select(x => x.StudentNumber).ToList();
        }

        /// <summary>
        /// Gets a list of all courseNumbers from the database.
        /// </summary>
        /// <returns>Returns an IEnumeable<string> of courseNumbers</returns>
        private IEnumerable<string> getCourseNumbers()
        {
            return db.Courses.Select(x => x.CourseNumber).ToList();
        }

        /// <summary>
        /// Gets a list of registrationNumbers from the database
        /// </summary>
        /// <returns>Returns an IEnumeable<long> of registrationNumbers</returns>
        private IEnumerable<long> getRegistrationNumbers()
        {
            return db.Registrations.Select(x => x.RegistrationNumber).ToList();
        }

        /// <summary>
        /// Calculate a valid CheckSum value from the contents of the input file.
        /// </summary>
        /// <param name="xDocument"></param>
        /// <returns>returns a long value of a sumarization of all student numbers</returns>
        private long calculateCheckSumFromFile(XDocument xDocument)
        {
            long totalStudentNumbers = 0;
            IEnumerable<XElement> xTransanctions = xDocument.Descendants("transaction");
            IEnumerable<XElement> allStudentNumbers = xTransanctions.Elements("student_no");
            foreach (XElement studentNumber in allStudentNumbers)
            {
                totalStudentNumbers += int.Parse(studentNumber.Value);
            }
            return totalStudentNumbers;
        }
    }
}