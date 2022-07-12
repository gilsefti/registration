using Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Context
{
    public interface IStorageContext
    {
        public List<Course> AllCourses { get; set; }
        public List<Student> AllStudents { get; set; }
    }
}
