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
    public partial class StudentRegistrations : System.Web.UI.Page
    {
        private BITCollege_EUContext db = new BITCollege_EUContext();
        int studentNumber = 0;
        
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
                        studentNumber = int.Parse(Page.User.Identity.Name.Split('@')[0]);
                        Session["StudentNumber"] = studentNumber;
                        populateStudentData(getStudent(studentNumber));
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
        /// Method to get a Student Object from the databse
        /// </summary>
        /// <param name="studentNumber">StudentNumber to execute a search in LINQ</param>
        /// <returns></returns>
        private Student getStudent(int studentNumber)
        {
            return db.Students.Where(x => x.StudentNumber == studentNumber).SingleOrDefault();
        }

        /// <summary>
        /// Method whichs obtains a Registration based on the StudentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        private IQueryable<Registration> getStudentRegistrations(int studentId) 
        {
            return db.Registrations.Where(x => x.StudentId == studentId);
        }

        /// <summary>
        /// Private method to populate some web Controls
        /// </summary>
        /// <param name="student"></param>
        private void populateStudentData(Student student)
        {
            lblStudent.Text = student.FullName;
            //List<Registration> registrationsObtained = getStudentRegistrations(student.StudentId).ToList();
            IQueryable<Registration> registrationsObtained = getStudentRegistrations(student.StudentId);

            lblMessage.Text = "Click the Select Link beside a registration (Above) to View or Drop the course";

            lblException.Text = "Error/Message (Visible = true only when displaying an error)";

            RegistrationGridView.DataSource = registrationsObtained.ToList();
            this.DataBind();

            Session["RegistrationsObtained"] = registrationsObtained;
        }

        protected void DataGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = RegistrationGridView.SelectedRow.Cells[1].Text;
            Session["SelectedCourseNumber"] = RegistrationGridView.SelectedRow.Cells[1].Text;
            Response.Redirect("~/ViewDrop.aspx");
        }

        protected void linkBtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CourseRegistration.aspx");
        }
    }
 }
