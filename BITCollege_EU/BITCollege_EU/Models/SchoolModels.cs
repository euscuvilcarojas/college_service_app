using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility;
using System.Globalization;
using BITCollege_EU.Data;
using System.Data.SqlClient;

namespace BITCollege_EU.Models
{
    /// <summary>
    /// Abstract class for Grade Point State
    /// </summary>
    public abstract class GradePointState
    {
        private BITCollege_EUContext db = new BITCollege_EUContext();

        /// <summary>
        /// Gets or Sets the GradePointStateId
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GradePointStateId { get; set; }

        /// <summary>
        /// Gets or Sets the LowerLimit
        /// </summary>
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        [Display(Name = "Lower\nLimit")]
        public double LowerLimit { get; set; }

        /// <summary>
        /// Gets or Sets the UpperLimit
        /// </summary>
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        [Display(Name = "Upper\nLimit")]
        public double UpperLimit { get; set; }

        /// <summary>
        /// Gets or Sets the TuitionRateFactor
        /// </summary>
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        [Display(Name = "Tuition\nRatre\nFactor")]
        public double TuitionRateFactor { get; set; }

        /// <summary>
        /// Gets the Description which is obtained from the instanceName
        /// </summary>
        [Display(Name = "Grade Point\nState")]
        public string Description
        {
            get
            {
                return Utility.Utils.ExtractStringFromInstanceName(this, "State");
            }
        }


        /// <summary>
        /// Represents the relationship between Student and GradePointState
        /// </summary>
        public virtual ICollection<Student> Student { get; set; }

        public virtual double TuitionRateAdjustment(Student student) { return 0.0; }

        public virtual void StateChangeCheck(Student student) {
        }
    }

    /// <summary>
    /// Class for Suspended State
    /// </summary>
    public class SuspendedState : GradePointState
    {
        private const double lowerLimitConst = 0.00;
        private const double upperLimitConst = 1.00;
        private const double tuitionRateConst = 1.1;

        private static BITCollege_EUContext db = new BITCollege_EUContext();
        private static SuspendedState suspendedState;

        //private constructor to force use of getInstance() to create a Singleton object.
        private SuspendedState() {
            this.LowerLimit = lowerLimitConst;
            this.UpperLimit = upperLimitConst;
            this.TuitionRateFactor = tuitionRateConst;
        }

        /// <summary>
        /// Handles the implementation of the singleton pattern
        /// </summary>
        /// <returns>Retrieves always an object of type SuspendedState with constant values</returns>
        public static SuspendedState GetInstance() {
            if (suspendedState == null) {
                //Populate suspendedState from the database.
                suspendedState = db.SuspendedStates.SingleOrDefault();
                if (suspendedState == null) {
                    suspendedState = new SuspendedState();
                    //Persisting records to the database
                    db.SuspendedStates.Add(suspendedState);
                    db.SaveChanges();
                }
            }
            return suspendedState;
        }

        /// <summary>
        /// This method handles all the scenarios where the tuitionRate is adjusted in Suspended State
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public override double TuitionRateAdjustment(Student student)
        {
            double adjustedTuitionRate = this.TuitionRateFactor;

            if (student.GradePointAverage < 0.50) {

                adjustedTuitionRate += 0.05;

            } else if (student.GradePointAverage < 0.75) {

                adjustedTuitionRate += 0.02;
            }

            return adjustedTuitionRate;
        }

        /// <summary>
        /// This method verifies is the the student requires a change of state based on his GPA
        /// </summary>
        /// <param name="student"></param>
        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage > this.UpperLimit) {
                //Going to probation state
                student.GradePointStateId = ProbationState.GetInstance().GradePointStateId;
                db.SaveChanges();
            }
        }
    }

    /// <summary>
    /// Class for Probation State which inherits from GradePointState
    /// </summary>
    public class ProbationState : GradePointState
    {
        private const double lowerLimitConst = 1.00;
        private const double upperLimitConst = 2.00;
        private const double tuitionRateConst = 1.075;
        private static BITCollege_EUContext db = new BITCollege_EUContext();

        private static ProbationState probationState;

        private ProbationState() {
            this.LowerLimit = lowerLimitConst;
            this.UpperLimit = upperLimitConst;
            this.TuitionRateFactor = tuitionRateConst;
        }

        /// <summary>
        /// Handles the implementation of the singleton pattern
        /// </summary>
        /// <returns>Retrieves always an object of type Probation State with constant values</returns>
        public static ProbationState GetInstance() {
            if (probationState == null) {
                probationState = db.ProbationStates.SingleOrDefault();
                if (probationState == null) {
                    probationState = new ProbationState();
                    //Persisting records to the database
                    db.ProbationStates.Add(probationState);
                    db.SaveChanges();
                }
            }
            return probationState;
        }

        /// <summary>
        /// This method handles all the scenarios where the tuitionRate is adjusted
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public override double TuitionRateAdjustment(Student student)
        {
            double adjustedTuitionRate = this.TuitionRateFactor;
            int cumpletedCurses = (from results in db.Registrations
                                   where (results.StudentId == student.StudentId && results.Grade != null) select results).Count();

            if (cumpletedCurses >= 5)
            {
                adjustedTuitionRate -= 0.035;
            }

            return adjustedTuitionRate;
        }

        /// <summary>
        /// This method verifies is the the student requires a change of state based on his GPA
        /// </summary>
        /// <param name="student"></param>
        public override void StateChangeCheck(Student student)
        {
            //Going to Regular state from Probation state
            if (student.GradePointAverage > this.UpperLimit) {
                student.GradePointStateId = RegularState.GetInstance().GradePointStateId;
                db.SaveChanges();
            }

            //Going to Suspended state from Probation state
            if (student.GradePointAverage < this.LowerLimit) {
                student.GradePointStateId = SuspendedState.GetInstance().GradePointStateId;
                db.SaveChanges();
            }
        }
    }

    /// <summary>
    /// Class for Regular State which inherits from GradePointState
    /// </summary>
    public class RegularState : GradePointState
    {
        private static RegularState regularState;
        private const double lowerLimitConst = 2.00;
        private const double upperLimitConst = 3.70;
        private const double tuitionRateConst = 1.0;
        private static BITCollege_EUContext db = new BITCollege_EUContext();

        private RegularState() {
            this.LowerLimit = lowerLimitConst;
            this.UpperLimit = upperLimitConst;
            this.TuitionRateFactor = tuitionRateConst;
        }

        /// <summary>
        /// Handles the implementation of the singleton pattern.
        /// </summary>
        /// <returns>Returns an object of type RegularState with constant values</returns>
        public static RegularState GetInstance() {
            if (regularState == null) {
                regularState = db.RegularStates.SingleOrDefault();
                if (regularState == null) {
                    regularState = new RegularState();
                    //Persisting records to the database
                    db.RegularStates.Add(regularState);
                    db.SaveChanges();
                }
            }
            return regularState;
        }

        public override double TuitionRateAdjustment(Student student)
        {
            return base.TuitionRateAdjustment(student);
        }

        /// <summary>
        /// This method verifies is the the student requires a change of state based on his GPA
        /// </summary>
        /// <param name="student"></param>
        public override void StateChangeCheck(Student student)
        {
            //Going from Regular state to Honours State
            if (student.GradePointAverage > UpperLimit) {
                student.GradePointStateId = HonoursState.GetInstance().GradePointStateId;
                db.SaveChanges();
            }

            //Going from Regular state to Probation State
            if (student.GradePointAverage < LowerLimit) {
                student.GradePointStateId = ProbationState.GetInstance().GradePointStateId;
                db.SaveChanges();
            }
        }
    }

    /// <summary>
    /// Class for Honours State which inherits from GradePointState
    /// </summary>
    public class HonoursState : GradePointState
    {
        private const double lowerLimitConst = 3.70;
        private const double upperLimitConst = 4.50;
        private const double tuitionRateConst = 0.9;
        private static BITCollege_EUContext db = new BITCollege_EUContext();
        private static HonoursState honoursState;

        private HonoursState() {
            this.LowerLimit = lowerLimitConst;
            this.UpperLimit = upperLimitConst;
            this.TuitionRateFactor = tuitionRateConst;
        }

        /// <summary>
        /// Method which handles the Singleton pattern implementation.
        /// </summary>
        /// <returns>Retrieves always an object of type HonourState with constant values</returns>
        public static HonoursState GetInstance() {
            if (honoursState == null) {
                honoursState = db.HonoursStates.SingleOrDefault();
                if (honoursState == null) {
                    honoursState = new HonoursState();
                    //Persisting records to the database
                    db.HonoursStates.Add(honoursState);
                    db.SaveChanges();
                }
            }
            return honoursState;
        }

        /// <summary>
        /// This method handles all the scenarios where the tuitionRate is adjusted
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public override double TuitionRateAdjustment(Student student)
        {
            double adjustedTuitionRate = this.TuitionRateFactor;
            int completedCourses = (from results in db.Registrations
                                    where (results.StudentId == student.StudentId && results.Grade != null) select results).Count();

            if (completedCourses >= 5 && student.GradePointStateId == HonoursState.GetInstance().GradePointStateId) {
                adjustedTuitionRate -= 0.05;
            }

            if (student.GradePointAverage > 4.25) {
                adjustedTuitionRate -= 0.02;
            }

            return adjustedTuitionRate;
        }

        /// <summary>
        /// This method verifies is the the student requires a change of state based on his GPA
        /// </summary>
        /// <param name="student"></param>
        public override void StateChangeCheck(Student student)
        {
            //Going from Honours State to Regular State
            if (student.GradePointAverage < LowerLimit) {
                student.GradePointStateId = RegularState.GetInstance().GradePointStateId;
                db.SaveChanges();
            }
        }
    }

    /// <summary>
    /// Class for Student
    /// </summary>
    public class Student
    {

        private BITCollege_EUContext db = new BITCollege_EUContext();

        /// <summary>
        /// Gets or Sets the  StudentId
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or Sets the GradePointStateId 
        /// </summary>
        [Required]
        [ForeignKey("GradePointState")]
        public int GradePointStateId { get; set; }

        /// <summary>
        /// Gets or Sets the AcademicProgramId
        /// </summary>
        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; }

        /// <summary>
        /// Gets or Sets the StudentNumber
        /// </summary>
        [Display(Name = "Student\nNumber")]
        public long StudentNumber { get; set; }

        /// <summary>
        /// Gets or Sets the FirstName
        /// </summary>
        [Required]
        [StringLength(35, MinimumLength = 1)]
        [Display(Name = "First\nName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        [Required]
        [StringLength(35, MinimumLength = 1)]
        [Display(Name = "Last\nName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets the Address
        /// </summary>
        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets the Province
        /// </summary>
        [Required]
        [RegularExpression("^(?:AB|BC|MB|N[BLTSU]|ON|PE|QC|SK|YT)*$", ErrorMessage = "Please insert a valid Canadian province abbreviation")]
        public string Province { get; set; }

        /// <summary>
        /// Gets or Sets the PostalCode
        /// </summary>
        [Required]
        [StringLength(7, MinimumLength = 7)]
        [RegularExpression("^([ABCEGHJKLMNPRSTVXY][0-9][A-Z] [0-9][A-Z][0-9])*$", ErrorMessage = "Please insert a valid Canadian PostalCode")]
        [Display(Name = "Postal\nCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or Sets the DateCreated
        /// </summary>
        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or Sets the GradePointAverage
        /// </summary>
        [Range(0, 4.5)]
        [Display(Name = "Grade Point\nAverage")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double? GradePointAverage { get; set; }

        /// <summary>
        /// Gets or Sets the OutstandingFees
        /// </summary>
        [Required]
        [Display(Name = "Outstanding\nFees")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        public double OutstandingFees { get; set; }

        /// <summary>
        /// Gets or Sets the Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets the FullName which is derived from FirstName and LastName
        /// </summary>
        [Display(Name = "Name")]
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        /// <summary>
        /// Gets the FullAddress which is derived from Address, City, Province and PostalCode
        /// </summary>
        [Display(Name = "Address")]
        public string FullAddress
        {
            get { return String.Format("{0} {1}, {2} {3}", Address, City, Province, PostalCode); }
        }

        /// <summary>
        /// Represents the relationship between GradePointState and Student
        /// </summary>
        public virtual GradePointState GradePointState { get; set; }

        /// <summary>
        /// Represents the relationship between AcademicProgram and Student
        /// </summary>
        public virtual AcademicProgram AcademicProgram { get; set; }


        /// <summary>
        /// Represents the relationship between Registration and Student
        /// </summary>
        public virtual ICollection<Registration> Registration { get; set; }

        /// <summary>
        /// Represents the relationship between Student and StudentCard
        /// </summary>
        public ICollection<StudentCard> StudentCard { get; set; }

        /// <summary>
        /// This methods handles the many changes in the states of the Student.
        /// </summary>
        public void ChangeState() {
            GradePointState actualGradePointState;
            GradePointState newGradePointState;
            do
            {
                //Execute the change of state
                actualGradePointState = db.GradePointStates.Find(this.GradePointStateId);
                actualGradePointState.StateChangeCheck(this);
                newGradePointState = db.GradePointStates.Find(this.GradePointStateId);
            }
            //Until the GradePointState are no longer different
            while (actualGradePointState.GradePointStateId != newGradePointState.GradePointStateId);
        }

        /// <summary>
        /// This method handles the many changes in the student number
        /// </summary>
        public void SetNextStudentNumber() {
            this.StudentNumber = (long)StoredProcedure.NextNumber("NextStudent");
        }
    }

    /// <summary>
    /// Class for Student Cards
    /// </summary>
    public class StudentCard
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentCardId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required]
        public long CardNumber { get; set; }

        /// <summary>
        /// Property which represent the relationship between StudentCard and Student    
        /// </summary>
        public Student Student { get; set; }
    }

    /// <summary>
    /// Class for Academic Program
    /// </summary>
    public class AcademicProgram
    {

        /// <summary>
        /// Gets or Sets the AcademicProgramId
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AcademicProgramId { get; set; }

        /// <summary>
        /// Gets or Sets the ProgramAcronym
        /// </summary>
        [Required]
        [Display(Name = "Program")]
        public string ProgramAcronym { get; set; }

        /// <summary>
        /// Gets or Sets the Description
        /// </summary>
        [Required]
        [Display(Name = "Program\nName")]
        public string Description { get; set; }

        /// <summary>
        /// Represents the relationship between AcademicProgram and Student
        /// </summary>
        public virtual ICollection<Student> Student { get; set; }

        /// <summary>
        /// Represents the relationship between AcademicProgram and Course
        /// </summary>
        public virtual ICollection<Course> Course { get; set; }
    }

    /// <summary>
    /// Class for Registration
    /// </summary>
    public class Registration
    {

        /// <summary>
        /// Gets or Sets the RegistrationId
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }

        /// <summary>
        /// Gets or Sets the StudentId 
        /// </summary>
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or Sets the CourseId
        /// </summary>
        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or Sets the RegistrationNumber
        /// </summary>
        [Display(Name = "Registration\nNumber")]
        public long RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or Sets the RegistrationDate
        /// </summary>
        [Required]
        [Display(Name = "Registration\nDate")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = ("{0:dd/MM/yyyy}"))]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Gets or Sets the Grade
        /// </summary>
        [DisplayFormat(NullDisplayText = "Ungraded")]
        [Range(0, 1)]
        public double? Grade { get; set; }

        /// <summary>
        /// Gets or Sets the Notes
        /// </summary>
        public string Notes { get; set; }

        //Navigation Reference

        /// <summary>
        /// Represents the relationship between Registration and Student
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// Represents the relationship between Registration and Course
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// This method handles all the changes in Registration number
        /// </summary>
        public void SetNextRegistrationNumber() {
            this.RegistrationNumber = (long)StoredProcedure.NextNumber("NextRegistration");
        }
    }

    /// <summary>
    /// Abstract class for Course
    /// </summary>
    public abstract class Course
    {

        /// <summary>
        /// Gets or Sets the CourseId
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CourdeId { get; set; }

        /// <summary>
        /// Gets or Sets the AcademicProgramId
        /// </summary>
        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; }

        /// <summary>
        /// Gets or Sets the CourseNumber
        /// </summary>
        [Display(Name = "Course\nNumber")]
        public String CourseNumber { get; set; }

        /// <summary>
        /// Gets or Sets the Title
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets the CreditHours
        /// </summary>
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        [Display(Name = "Credit\nHours")]
        public double CreditHours { get; set; }

        /// <summary>
        /// Gets or Sets the TuitionAmount
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Tuition\nAmount")]
        public double TuitionAmount { get; set; }

        /// <summary>
        /// Gets the CourseType which is obtained from the instanceName
        /// </summary>
        [Display(Name = "Course\nType")]
        public string CourseType
        {
            get
            {
                return Utility.Utils.ExtractStringFromInstanceName(this, "Course");
            }
        }

        /// <summary>
        /// Gets or Sets the Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Represents the relationship between Course and AcademicProgram
        /// </summary>
        public virtual AcademicProgram AcademicProgram { get; set; }

        /// <summary>
        /// Represents the relationship between Course and Registration
        /// </summary>
        public virtual ICollection<Registration> Registration { get; set; }

        /// <summary>
        /// Handles the changes in Course Number
        /// </summary>
        public virtual void SetNextCourseNumber() { }
    }

    /// <summary>
    /// Class for GradedCourse which inherits from Course
    /// </summary>
    public class GradedCourse : Course
    {

        /// <summary>
        /// Gets or Sets the AssignmentWeight
        /// </summary>
        [Required]
        [Display(Name = "Assignment\nWeight")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double AssignmentWeight { get; set; }

        /// <summary>
        /// Gets or Sets the MidTermWeight
        /// </summary>
        [Required]
        [Display(Name = "Midterm\nWeight")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double MidTermWeight { get; set; }

        /// <summary>
        /// Gets or Sets the FinalWeight
        /// </summary>
        [Required]
        [Display(Name = "Final\nWeight")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double FinalWeight { get; set; }

        /// <summary>
        /// Custom implementation which handles the changes in course number
        /// </summary>
        public override void SetNextCourseNumber()
        {
            this.CourseNumber = "G-" + StoredProcedure.NextNumber("NextGradedCourse");
        }
    }

    /// <summary>
    /// Class for AuditCourse which inherits from Course
    /// </summary
    public class AuditCourse : Course {

        /// <summary>
        /// Custom implementation that handles the changes in Course Number
        /// </summary>
        public override void SetNextCourseNumber()
        {
            this.CourseNumber = "A-" + StoredProcedure.NextNumber("NextAuditCourse");
        }
    }

    /// <summary>
    /// Class for MasteryCourse which inherits from Course
    /// </summary>
    public class MasteryCourse : Course
    {

        /// <summary>
        /// Gets or Sets the MaximumAttempts
        /// </summary>
        [Required]
        [Display(Name = "Maximum\nAttempts")]
        public int MaximumAttempts { get; set; }

        /// <summary>
        /// Custom implementation that handles the changes in Course Number
        /// </summary>
        public override void SetNextCourseNumber(){
            this.CourseNumber = "M-" + StoredProcedure.NextNumber("NextMasteryCourse");
        }
    }

    /// <summary>
    /// Abstract class Next Unique Number
    /// </summary>
    public abstract class NextUniqueNumber 
    {
        protected static BITCollege_EUContext db = new BITCollege_EUContext();

        /// <summary>
        /// Primary key of NextUniqueNumber
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextUniqueNumberId { get; set; }

        /// <summary>
        /// Property which representst he Next Available Number for the class
        /// </summary>
        [Required]
        public long NextAvailableNumber { get; set; }
    }

    public class NextGradedCourse : NextUniqueNumber{

        private static NextGradedCourse nextGradedCourse;

        private NextGradedCourse() {
            NextAvailableNumber = 200000;
        }

        /// <summary>
        /// Property which handles the implementation of the Singleton pattern
        /// </summary>
        /// <returns>Returns an instanciated object of type NextGradedCourse</returns>
        public static NextGradedCourse GetInstance(){
            if (nextGradedCourse == null) {
                //Populating nextGradedCourse with values from the database
                nextGradedCourse = db.NextGradedCourses.SingleOrDefault();
                if (nextGradedCourse == null) {
                    nextGradedCourse = new NextGradedCourse();
                    //Persisting nextGradedCourse to the database
                    db.NextGradedCourses.Add(nextGradedCourse);
                    db.SaveChanges();
                }
            }
            return nextGradedCourse;
        }
    }

    public class NextAuditCourse : NextUniqueNumber {
        private static NextAuditCourse nextAuditCourse;

        private NextAuditCourse() {
            NextAvailableNumber = 2000;
        }

        /// <summary>
        /// Property which handles the implementation of the Singleton pattern
        /// </summary>
        /// <returns>Returns an instanciated object of type NextAuditCourse</returns>
        public static NextAuditCourse GetInstance(){
            if (nextAuditCourse == null) {
                //Populating nextAuditCourse with values from the database
                nextAuditCourse = db.NextAuditCourses.SingleOrDefault();
                if (nextAuditCourse == null) {
                    nextAuditCourse = new NextAuditCourse();
                    //Persinting nextAuditCourse to the database;
                    db.NextAuditCourses.Add(nextAuditCourse);
                    db.SaveChanges();
                }
            }
            return nextAuditCourse;
        }
    }

    public class NextMasteryCourse : NextUniqueNumber {
        private static NextMasteryCourse nextMasteryCourse;

        private NextMasteryCourse() {
            NextAvailableNumber = 20000;
        }

        /// <summary>
        /// Property which handles the implementation of the Singleton pattern
        /// </summary>
        /// <returns>Returns an instanciated object of type NextMasteryCourse</returns>
        public static NextMasteryCourse GetInstance() {
            if (nextMasteryCourse == null) {
                //Populating nextMasteryCourse with values from the database
                nextMasteryCourse = db.NextMasteryCourses.SingleOrDefault();
                if (nextMasteryCourse == null) {
                    nextMasteryCourse = new NextMasteryCourse();
                    //Persisting nextMasteryCourse to the database
                    db.NextMasteryCourses.Add(nextMasteryCourse);
                    db.SaveChanges();
                }
            }
            return nextMasteryCourse;
        }
    }

    public class NextStudent : NextUniqueNumber {
        private static NextStudent nextStudent;

        private NextStudent() {
            NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Property which handles the implementation of the Singleton pattern
        /// </summary>
        /// <returns>Returns an instanciated object of type NextStudent</returns>
        public static NextStudent GetInstance() {
            if (nextStudent == null) {
                //Populate nextStudent with values from the database
                nextStudent = db.NextStudents.SingleOrDefault();
                if (nextStudent == null) {
                    nextStudent = new NextStudent();
                    //Persingint records to the database
                    db.NextStudents.Add(nextStudent);
                    db.SaveChanges();
                }
            }
            return nextStudent;
        }
    }

    public class NextRegistration : NextUniqueNumber {
        private static NextRegistration nextRegistration;

        private NextRegistration() {
            NextAvailableNumber = 700;
        }

        /// <summary>
        /// Property which handles the implementation of the Singleton pattern
        /// </summary>
        /// <returns>Returns an instanciated object of type NextRegistration</returns>
        public static NextRegistration GetInstance() {
            if (nextRegistration == null) {
                //Populates nextRegistration with values from the database
                nextRegistration = db.NextRegistrations.SingleOrDefault();
                if (nextRegistration == null) {
                    nextRegistration = new NextRegistration();
                    //Persists nextRegistration to the database
                    db.NextRegistrations.Add(nextRegistration);
                    db.SaveChanges();
                }
            }
            return nextRegistration;
        }
    }

    /// <summary>
    /// Method wich handles the execution of stored procedures from C#
    /// </summary>
    /// <returns>Returns the variaable returnValue which would contain the output value from the stored procedure executed.</returns>
    public static class StoredProcedure {
        public static long? NextNumber(string discriminator) {
            long? returnValue = 0;
            try
            {
                //Creating a database connection of type SqlConnection
                SqlConnection connection = new SqlConnection("Data Source=localhost; " +
                                            "Initial Catalog=BITCollege_EUContext;Integrated Security=True");

                //Creating an object storedProcedure of type SqlCommand which looks for the procedure "next_number"
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);
                storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;

                //Filling the stored procedure input parameter @Discriminator with the argument discriminator
                storedProcedure.Parameters.AddWithValue("@Discriminator", discriminator);

                //Setting the variable outputParameter to receive the @NewVal output parameter of the stored procedure.
                SqlParameter outputParameter = new SqlParameter("@NewVal", System.Data.SqlDbType.BigInt)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                storedProcedure.Parameters.Add(outputParameter);
                connection.Open();
                storedProcedure.ExecuteNonQuery();
                connection.Close();
                returnValue = (long?)outputParameter.Value;
                return returnValue;
            }
            catch (Exception e) {
                returnValue = null;
            }
            return returnValue;
        }
    }
}
