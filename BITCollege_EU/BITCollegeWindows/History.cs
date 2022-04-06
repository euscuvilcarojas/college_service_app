using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BITCollege_EU.Data;
using BITCollege_EU.Models;

namespace BITCollegeWindows
{
    public partial class History : Form
    {
        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;
        private BITCollege_EUContext db = new BITCollege_EUContext();


        public History()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when called from the
        /// Student form.  This constructor will receive 
        /// specific information about the student and registration
        /// further code required:  
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public History(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;
            //further code to be added
        }

        /// <summary>
        /// given: this code will navigate back to the Student form with
        /// the specific student and registration data that launched
        /// this form.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to student with the data selected for this form
            StudentData student = new StudentData(constructorData);
            student.MdiParent = this.MdiParent;
            student.Show();
            this.Close();
        }

        /// <summary>
        /// given:  open in top right of frame
        /// further code required:
        /// </summary>
        private void History_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            try
            {
                populateGridView(constructorData.student.StudentId);
                loadRegistrationInformation();
            }
            catch (Exception exception) {
                MessageBox.Show("ERROR: " + exception.Message);
            }
        }

        /// <summary>
        /// Private method which handles the Registration information in the form
        /// </summary>
        private void loadRegistrationInformation() {
            Student studentFound = getStudent(constructorData.student.StudentNumber);
            studentBindingSource.DataSource = studentFound;
            academicProgramBindingSource.DataSource = getAcademicProgram((int)studentFound.AcademicProgramId);
        }

        /// <summary>
        /// Retrieves a Student object based on its studentNumber
        /// </summary>
        /// <param name="studentNumber"></param>
        /// <returns>Student object</returns>
        private Student getStudent(long studentNumber)
        {
            return db.Students.Where(x => x.StudentNumber == studentNumber).SingleOrDefault();
        }

        /// <summary>
        /// Retrieves an AcademicProgram object based on its academicProgramId
        /// </summary>
        /// <param name="academicProgramId"></param>
        /// <returns>AcademicProgram object</returns>
        private AcademicProgram getAcademicProgram(int academicProgramId ) {
            return db.AcademicPrograms.Where(x => x.AcademicProgramId== academicProgramId).SingleOrDefault();
        }

        /// <summary>
        /// Populates the datagridview based on a studentId
        /// </summary>
        private void populateGridView(int studentId) {
            var gridViewData = from registrationRecord in db.Registrations
                               join courseRecord in db.Courses on registrationRecord.CourseId equals courseRecord.CourdeId
                               where registrationRecord.StudentId == studentId
                               select new { 
                                   registrationRecord.RegistrationNumber,
                                   registrationRecord.RegistrationDate,
                                   courseTitle =  courseRecord.Title,
                                   registrationRecord.Grade,
                                   registrationRecord.Notes
                                 };
                               
            registrationBindingSource.DataSource = gridViewData.ToList(); 
        }
    }
}
