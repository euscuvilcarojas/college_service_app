using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    public partial class Grading : Form
    {
        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;
        private BITCollege_EUContext db = new BITCollege_EUContext();
        private BITCollegeServiceReference.CollegeRegistrationClient service = new BITCollegeServiceReference.CollegeRegistrationClient();

        public Grading()
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
        public Grading(ConstructorData constructorData)
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
            //student.MdiParent = this.MdiParent;
            student.Show();
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// given:  open in top right of frame
        /// further code required:
        /// </summary>
        private void Grading_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            populateFormData();
        }

        /// <summary>
        /// Private method which handles all the data population in the form.
        /// </summary>
        private void populateFormData() {
            try
            {
                Student student = getStudent(constructorData.student.StudentId);
                Registration registration = getRegistration(constructorData.registration.RegistrationId);
                if (student != null)
                {
                    studentBindingSource.DataSource = student;
                    registrationBindingSource.DataSource = registration;
                    courseNumberMaskedLabel.Mask = Utility.BusinessRules.CourseFormat(registration.Course.CourseType);
                    if (registration.Grade != null)
                    {
                        gradeTextBox.Enabled = false;
                        lnkUpdate.Enabled = false;
                        lblExisting.Visible = true;
                    }
                    else 
                    {
                        gradeTextBox.Enabled = true;
                        lnkUpdate.Enabled = true;
                        lblExisting.Visible = false;
                    }
                }
            }
            catch (Exception exception) {
                MessageBox.Show("ERROR: " + exception.Message);
            }
        }

        /// <summary>
        /// Retrieves a Student object based on its studentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Student object</returns>
        private Student getStudent(int studentId)
        {
            return db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();
        }

        /// <summary>
        /// Retrieves a Registration object based on its RegistrationId
        /// </summary>
        /// <param name="RegistrationId"></param>
        /// <returns>Returns a course object</returns>
        private Registration getRegistration(int RegistrationId) {
            return db.Registrations.Where(x => x.RegistrationId == RegistrationId).SingleOrDefault();
        }

        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string gradeTextWithoutMask = Utility.Numeric.ClearFormatting(gradeTextBox.Text, "%");

                if (!Utility.Numeric.IsNumeric(gradeTextWithoutMask, System.Globalization.NumberStyles.Float))
                {
                    MessageBox.Show("The value for grade is not a number");
                    gradeTextBox.Focus();
                }
                else
                {
                    double newGrade = Double.Parse(gradeTextWithoutMask) / 100;
                    if (newGrade < 0 || newGrade > 1)
                    {
                        MessageBox.Show("The value for grade is invalid - Correct Format: 57.50%");
                    }
                    else
                    {
                        double? result = service.UpdateGrade(newGrade, constructorData.registration.RegistrationId, "Notes");
                        if (result != null)
                        {
                            MessageBox.Show("Update Successful", "Grades");
                            gradeTextBox.Enabled = false;
                            lnkUpdate.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Update NOT Successful", "Grades");
                        }
                    }
                }
            }
            catch (Exception exception) {
                MessageBox.Show("ERROR: " + exception.Message);
            }
        }
    }
}
