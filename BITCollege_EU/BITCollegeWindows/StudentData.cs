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
    public partial class StudentData : Form
    {
        private BITCollege_EUContext db = new BITCollege_EUContext();

        ///Given: Student and Registration data will be retrieved
        ///in this form and passed throughout application
        ///These variables will be used to store the current
        ///Student and selected Registration
        ConstructorData constructorData = new ConstructorData();
        public StudentData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when returning to frmStudent
        /// from another form.  This constructor will pass back
        /// specific information about the student and registration
        /// based on activites taking place in another form
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public StudentData(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;

            //further code to be added  
        }

        /// <summary>
        /// given: open grading form passing constructor data
        /// </summary>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            constructorData.registration = (Registration)registrationBindingSource.Current;
            Grading grading = new Grading(constructorData);
            grading.MdiParent = this.MdiParent;
            grading.Show();
            this.Close();
        }

        /// <summary>
        /// given: open history form passing data
        /// </summary>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            History history = new History(constructorData);
            history.MdiParent = this.MdiParent;
            history.Show();
            this.Close();
        }
        /// <summary>
        /// given:  opens form in top right of frame
        /// </summary>
        private void StudentData_Load(object sender, EventArgs e)
        {
            //keeps location of form static when opened and closed
            this.Location = new Point(0, 0);

            //Clearing the bindings
            gradePointStateBindingSource.Clear();
            studentBindingSource.Clear();
            registrationBindingSource.Clear();

            if (constructorData.student != null) {
                populateFormData((int)constructorData.student.StudentNumber);
            }
            
        }
        
        private void studentNumberMaskedTextBox_Leave(object sender, EventArgs e)
        {
            populateFormData(Int32.Parse(studentNumberMaskedTextBox.Text.Replace("-", "")));
        }

        /// <summary>
        /// Private method which handles the data population based on a StudentNumber
        /// </summary>
        /// <param name="studentNumber"></param>
        private void populateFormData(int studentNumber) {
            try
            {
                Student studentFound = getStudent(studentNumber);
                if (studentFound is null)
                {
                    MessageBox.Show("Student " + studentNumberMaskedTextBox.Text.Replace("-", "") + " does not exist.", "Invalid Student Number");
                    //Disabling the link controls
                    lnkDetails.Enabled = false;
                    lnkUpdate.Enabled = false;
                    studentNumberMaskedTextBox.Focus();

                    //Clearing all the datasources
                    studentBindingSource.Clear();
                    registrationBindingSource.Clear();
                }
                else
                {
                    studentBindingSource.DataSource = studentFound;
                    gradePointStateBindingSource.DataSource = getGradePointState(studentFound.GradePointStateId);
                    
                    //Enabling the link controls
                    List<Registration> registrationsObtained = getRegistrations(studentFound.StudentId).ToList();
                    if (registrationsObtained.Count > 0)
                    {
                        registrationBindingSource.DataSource = registrationsObtained;
                        lnkDetails.Enabled = true;
                        lnkUpdate.Enabled = true;
                        // Populating the required objects
                        constructorData.student = studentFound;
                    }
                    else
                    {
                        lnkDetails.Enabled = false;
                        lnkUpdate.Enabled = false;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR: " + exception.Message);
            }
        }

        /// <summary>
        /// Retrieves a Student object based on its studentNumber
        /// </summary>
        /// <param name="studentNumber"></param>
        /// <returns>Student object</returns>
        private Student getStudent(int studentNumber)
        {
            return db.Students.Where(x => x.StudentNumber == studentNumber).SingleOrDefault();
        }

        /// <summary> 
        /// Retrieves a Collection of Registrations based on the StudentID
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Returns an Collection of type IQueryable of Registrations</returns>
        private IQueryable<Registration> getRegistrations(int studentId)
        {
            return db.Registrations.Where(x => x.StudentId == studentId);
        }

        /// <summary>
        /// Returns an object of type GradePointState 
        /// </summary>
        /// <param name="gradePointStateId"></param>
        /// <returns>Returns an object of type GradePointState</returns>
        private GradePointState getGradePointState(int gradePointStateId) {
            return db.GradePointStates.Where(x => x.GradePointStateId == gradePointStateId).SingleOrDefault();
        }
    }
}
