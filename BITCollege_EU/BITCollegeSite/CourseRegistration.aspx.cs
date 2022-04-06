using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_EU.Data;
using BITCollege_EU.Models;

namespace BITCollegeSite
{
    public partial class CourseRegistration : System.Web.UI.Page
    {
        private BITCollege_EUContext db = new BITCollege_EUContext();
        private CollegeRegistrationService.CollegeRegistrationClient service = new CollegeRegistrationService.CollegeRegistrationClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                try
                {
                    // Enforcing Authentication
                    if (!this.Page.User.Identity.IsAuthenticated)
                    {
                        Response.Redirect("~/Account/Login.aspx");
                    }
                    else
                    {
                        populateFields();
                    }
                }
                catch (Exception exception)
                {
                    lblException.Visible = true;
                    lblException.Text = exception.Message;
                }
            }
        }

        /// <summary>
        /// Populates all the controls in the web Form
        /// </summary>
        private void populateFields()
        {
            Student currentStudent = getStudent();

            List<Course> coursesObtainedList =
                getCoursesByAcademicProgram((int)currentStudent.AcademicProgramId).ToList();

            ddlCourse.DataSource = coursesObtainedList;
            ddlCourse.DataTextField = "Title";
            ddlCourse.DataValueField = "CourdeId";
            this.DataBind();

            lblStudent.Text = currentStudent.FullName;
        }

        /// <summary>
        /// Obtains a student object from the database
        /// </summary>
        /// <param name="studentNumber"></param>
        /// <returns>Student Object</returns>
        private Student getStudent() {
            IQueryable<Registration> filteredRegistrations = (IQueryable<Registration>)Session["RegistrationsObtained"];
            return filteredRegistrations.ToList().ElementAt(0).Student;
        }

        /// <summary>
        /// Returns all the Courses associated to an academicProgram
        /// </summary>
        /// <param name="academicProgramId"></param>
        /// <returns>Returns a List of courses per Academic Program</returns>
        private IQueryable<Course> getCoursesByAcademicProgram(int academicProgramId) {
            return db.Courses.
                Where(x => x.AcademicProgramId == academicProgramId);
        }

        protected void lnkBtnRegister_Click(object sender, EventArgs e)
        {
            rfvNotes.Enabled = true;
            rfvNotes.Visible = true;

            Page.Validate();
            if (Page.IsValid)
            {
                int courseId = int.Parse(ddlCourse.SelectedItem.Value);
                int studentId = getStudent().StudentId;

                int result = service.RegisterCourse(studentId, courseId, txtNotes.Text);

                if (result != 0)
                {
                    lblException.Visible = true;
                    lblException.Text = Utility.BusinessRules.RegisterError(result);
                }
                else
                {
                    Response.Redirect("~/StudentRegistrations.aspx");
                }
            }
        }

        protected void lnkBtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentRegistrations.aspx");
        }
    }
 }