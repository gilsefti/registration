using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Models
{
    public enum State
    {
        InProgress = 1,
        Completed = 2,
        Cancelled = 3,
        Payed = 4
    }
    public class Student
    {
        public string StudentId { get; set; }
        public List<Course> Courses { get; set; }
        public State State { get; set; }
    }
}
