using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BITCollege_EU.Data;
using BITCollege_EU.Models;


namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CollegeRegistration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CollegeRegistration.svc or CollegeRegistration.svc.cs at the Solution Explorer and start debugging.
    public class CollegeRegistration : ICollegeRegistration
    {
        private BITCollege_EUContext db = new BITCollege_EUContext();

        /// <summary>
        /// Drops a course which correspond to a registrationId
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns>returns TRUE if the operation is successful or FALSE if it is not.</returns>
        public bool DropCourse(int registrationId)
        {
            bool isSuccessful = true;
            //Obtaining the result;
            try
            {
                db.Registrations.Remove(db.Registrations.Find(registrationId));
                db.SaveChanges();
            }
            catch (Exception e) {
                isSuccessful = false;
            }
            return isSuccessful;
        }

        /// <summary>
        /// Registers a new course to the student record.
        /// </summary>
        /// <param name="studentId">Student table primary key</param>
        /// <param name="courseId">Course table primary key</param>
        /// <param name="notes">Registration notes</param>
        /// <returns>Returns 0 if registration is successful, return negative numbers in case of any business rule violation</returns>
        public int RegisterCourse(int studentId, int courseId, string notes)
        {
            Course courseToTake = db.Courses.Where(x => x.CourdeId == courseId).SingleOrDefault();
            Student student = db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();
            int successFlag = 0;

            successFlag = checkForIncompleteRegistrations(studentId, courseId);

            //For mastery courses only
            if (courseToTake.CourseType == "Mastery") {
                successFlag = checkForMaximumAttempts(studentId, courseId);
            }

            //Registering the course 
            try
            {
                if (successFlag == 0)
                {
                    //Assembling the object newRegistration
                    Registration newRegistration = new Registration();
                    newRegistration.CourseId = courseId;
                    newRegistration.StudentId = studentId;
                    newRegistration.SetNextRegistrationNumber();
                    newRegistration.Notes = notes;
                    newRegistration.RegistrationDate = DateTime.Now;
                    db.Registrations.Add(newRegistration);
                    db.SaveChanges();

                    //Updating the student's fees accordingly.
                    successFlag = updateStudentFees(courseToTake, student);
                }
            }
            catch (Exception e) {
                successFlag = -300;
            }
            return successFlag;
        }

        /// <summary>
        /// Checks if any course registration is incomplete (having a null as grade)
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns>Returns -100 in case of error or 0 if the check is successful</returns>
        private int checkForIncompleteRegistrations(int studentId, int courseId) 
        {
            IQueryable<Registration> registration = db.Registrations.Where(x => x.StudentId == studentId && x.CourseId == courseId && x.Grade == null);
            if (registration.Count() > 0)
            {
                return -100;
            }
            return 0;
        }

        /// <summary>
        /// Checks if the Student is exceeding the maximum amount of attempts for mastery courses
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        /// <returns>Returns -200 in case of error or 0 if the check is successful</returns>
        private int checkForMaximumAttempts(int studentId, int courseId) {
            //Getting already taken Attempts
            int attemptsTaken = db.Registrations.Where(x => x.CourseId == courseId && x.StudentId == studentId).Count();
            //Getting maximum attempts
            int maximumAttempts = db.MasteryCourses.Where(x => x.CourdeId == courseId).SingleOrDefault().MaximumAttempts;
            if (attemptsTaken >= maximumAttempts)
            {
                return  -200;
            }
            else 
            {
                return 0;
            }
        }

        /// <summary>
        /// Updates the student pending fees accordingly to each student GPA
        /// </summary>
        /// <param name="courseToTake"></param>
        /// <param name="student"></param>
        /// <returns>Returns -300 in case of error or 0 if the check is successful</returns>
        private int updateStudentFees(Course courseToTake, Student student) 
        {
            //Updating Student's outstanding fees
            //Handling the modification in the tuition amount (pending)
            try
            {
                switch (student.GradePointState.GetType().Name)
                {
                    case "SuspendedState":
                        student.OutstandingFees += (courseToTake.TuitionAmount) * (SuspendedState.GetInstance().TuitionRateAdjustment(student));
                        break;
                    case "ProbationState":
                        student.OutstandingFees += (courseToTake.TuitionAmount) * (ProbationState.GetInstance().TuitionRateAdjustment(student));
                        break;
                    case "RegularState":
                        student.OutstandingFees += (courseToTake.TuitionAmount) * (RegularState.GetInstance().TuitionRateAdjustment(student));
                        break;
                    case "HonoursState":
                        student.OutstandingFees += (courseToTake.TuitionAmount) * (HonoursState.GetInstance().TuitionRateAdjustment(student));
                        break;
                }
                db.SaveChanges();
                return 0;
            }
            catch (Exception e)
            {
                return -300;
            }
        }

        /// <summary>
        /// Updates the grade for a partiocular registration record
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="registrationId"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public double? UpdateGrade(double grade, int registrationId, string notes)
        {
            //Obtaining the registration record
            Registration registration = db.Registrations.Where(x => x.RegistrationId == registrationId).SingleOrDefault();

            //Updating the required information
            registration.Grade = grade;
            registration.Notes = notes;
            db.SaveChanges();

            //Calling the method CalculateGradePointAverage
            double newGradePointAverage = (double)CalculateGradePointAverage(registration.StudentId);

            //Persinting this change to the database
            Student student = db.Students.Where(x => x.StudentId == registration.StudentId).SingleOrDefault();
            student.GradePointAverage = newGradePointAverage;
            db.SaveChanges();
            
            return newGradePointAverage;
        }

        /// <summary>
        /// Calculates the new GradePointAverage after changes made in the student record.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Returns the new calculated GradePointAverage</returns>
        private double? CalculateGradePointAverage(int studentId) {
            IQueryable<Registration> registrationList = db.Registrations.Where(x => x.StudentId == studentId && x.Grade != null);
            Course course;
            double grade = 0;
            double gradePointValue;
            double totalGradePointValue = 0;
            double totalCreditHours = 0;
            double? calculatedGradePointAverage = 0;

            foreach (Registration registration in registrationList.ToList()) {
                grade = (double)registration.Grade;
                course = db.Courses.Where(x => x.CourdeId == registration.CourseId).SingleOrDefault();
                switch (course.CourseType) 
                { 
                    case "Graded":
                        gradePointValue = Utility.BusinessRules.GradeLookup(grade, Utility.CourseType.GRADED);
                        totalGradePointValue += (gradePointValue) * (course.CreditHours);
                        totalCreditHours += course.CreditHours;
                        break;
                    case "Mastery":
                        gradePointValue = Utility.BusinessRules.GradeLookup(grade, Utility.CourseType.MASTERY);
                        totalGradePointValue += (gradePointValue) * (course.CreditHours);
                        totalCreditHours += course.CreditHours;
                        break;
                }
            }

            if (totalCreditHours == 0)
            {
                calculatedGradePointAverage = null;
            }
            else
            {
                calculatedGradePointAverage = (totalGradePointValue / totalCreditHours);
            }

            //Obtaining the student record
            Student studentRecord = db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();
            studentRecord.GradePointAverage = calculatedGradePointAverage;
            db.SaveChanges();

            //Changing the GradePointState for the student
            studentRecord.ChangeState();

            return calculatedGradePointAverage;
        }
    }
}
