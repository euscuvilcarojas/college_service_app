using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICollegeRegistration" in both code and config file together.
    [ServiceContract]
    public interface ICollegeRegistration
    {

        /// <summary>
        /// This operattion drops a course from a student
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns>boolean</returns>
        [OperationContract]
        bool DropCourse(int registrationId);

        /// <summary>
        /// This operations registers a studdent into a course adding some notes
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <param name="notes"></param>
        /// <returns>Returns registrationId (self generated)</returns>
        [OperationContract]
        int RegisterCourse(int studentId, int courseId, string notes);
        

        /// <summary>
        /// This operation updates the grade of an student 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <param name="notes"></param>
        /// <returns>Returns the a nullable double if nece</returns>
        [OperationContract]
        double? UpdateGrade(double grade, int registrationId, string notes);
    }

}
