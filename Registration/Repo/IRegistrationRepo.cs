using Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Repo
{
   public interface IRegistrationRepo
    {
        public void CreateRegistration(string studentId);

        public void AddCourse(string studentId, string courseId);

        public void ClearAllCourses(string studentId);

        public void Complete(string studentId);

        public void Pay(string studentId);

        public void Cancel(string studentId);


       
       
    }
}
