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
    public partial class ViewDrop : System.Web.UI.Page
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
                        populateRegistrationData();
                        isDropAble();
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
        /// Obtains a Student object
        /// </summary>
        /// <param name="studentNumber">StudentNumber is used as a parameter for the query</param>
        /// <returns></returns>
        private Student getStudent(int studentNumber) 
        {
            return db.Students.Where(x => x.StudentNumber == studentNumber).SingleOrDefault();
        }   

        /// <summary>
        /// Obtains a Course object
        /// </summary>
        /// <param name="courseNumber">courseNumber is used as a parameter for the query</param>
        /// <returns></returns>
        private Course getCourse(string courseNumber)
        {
            return db.Courses.Where(x => x.CourseNumber == courseNumber).SingleOrDefault();
        }

        /// <summary>
        /// Obtains all the registrations per CourseId and StudentId
        /// </summary>
        /// <param name="courseId">CourseId is used as parameter for the query</param>
        /// <param name="studentId">StudentId is used as parameter for the query</param>
        /// <returns></returns>
        private IQueryable<Registration> getFilteredRegistrations(int courseId)
        {
            IQueryable<Registration> filteredRegistrations = (IQueryable<Registration>)Session["RegistrationsObtained"];
            return filteredRegistrations.Where(x => x.CourseId == courseId);
        }

        /// <summary>
        /// Populates the DetailView with he registrations filtered by courseId
        /// </summary>
        private void populateRegistrationData() {
            int courseId = getCourse(Session["SelectedCourseNumber"] as string).CourdeId;
            IQueryable<Registration> filteredRegistrationList = getFilteredRegistrations(courseId);
            Session["FilteredRegistrationRecords"] = filteredRegistrationList.ToList();
            courseDetailView.DataSource = filteredRegistrationList.ToList();
            this.DataBind();
        }

        /// <summary>
        /// Function that checks if a registration record has a null for grade and enable/disables drop link button.
        /// </summary>
        private void isDropAble()
        {
            List<Registration> filteredRegistrationRecords = (List<Registration>)Session["FilteredRegistrationRecords"];
            Registration filteredRegistrationRecord = filteredRegistrationRecords[courseDetailView.PageIndex];

            if (filteredRegistrationRecord.Grade != null)
            {
                linkBtnDrop.Enabled = false;
                lblException.Text = "Courses without a grade cannot be dropped";
            }
            else
            {
                linkBtnDrop.Enabled = true;
            }
        }

        protected void linkBtnDrop_Click(object sender, EventArgs e)
        {
            List<Registration> filteredRegistrationRecords = (List<Registration>)Session["FilteredRegistrationRecords"];
            Registration filteredRegistrationRecord = filteredRegistrationRecords[courseDetailView.PageIndex];

            if (service.DropCourse(filteredRegistrationRecord.RegistrationId))
            {
                Response.Redirect("~/StudentRegistrations.aspx");
            }
            else 
            {
                lblException.Text = "The course could not be dropped please review the bussines rules";
            }
        }

        protected void linkBtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentRegistrations.aspx");
        }

        protected void courseDetailView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            courseDetailView.DataSource = Session["FilteredRegistrationRecords"];
            courseDetailView.PageIndex = e.NewPageIndex;
            this.DataBind();
            isDropAble();
        }
    }
}