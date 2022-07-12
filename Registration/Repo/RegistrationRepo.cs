using Registration.Context;
using Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Repo
{
    public class RegistrationRepo: IRegistrationRepo
    {
        IStorageContext Storage;
        public RegistrationRepo(IStorageContext storage)
        {
            this.Storage = storage;
        }
        public void CreateRegistration(string studentId)
        {
            var student = FindStudent(studentId);
            if (student == null)
                student = new Student() { StudentId = studentId };
            if (student.State == 0)
                student.State = State.InProgress;
            else
                throw new Exception("State already exists");
        }
        public void AddCourse(string studentId, string courseId) {
            var student = FindStudent(studentId);
            if (student.State == State.Payed || student.State == State.Cancelled)
                return;
            var course = FindCourse(courseId);
            if (!student.Courses.Contains(course))
                student.Courses.Add(course);
            if (student.Courses.Count == Storage.AllCourses.Count())
                student.State = State.Completed;
        }
        public void ClearAllCourses(string studentId) {
            var student = FindStudent(studentId);
            if (student.State == State.Payed || student.State == State.Cancelled)
                return;
            student.Courses.Clear();         
        }
        public void Complete(string studentId)
        {
            var student = FindStudent(studentId);
            if (student.State == State.InProgress)
                student.State = State.Completed;                
        }
        public void Pay(string studentId)
        {
            var student = FindStudent(studentId);
            if (student.State == State.Completed)
                student.State = State.Payed;
        }
        public void Cancel(string studentId)
        {
            var student = FindStudent(studentId);
            if (student.State == State.InProgress || student.State == State.Completed)
                student.State = State.Cancelled;
        }
       
        Student FindStudent(string studentId) {
            var student = Storage.AllStudents.Where(student => student.StudentId == studentId).FirstOrDefault();
            return student;
        }
        Course FindCourse(string courseId) {
            var course = Storage.AllCourses.First(course => course.CourseId == courseId);
            return course;
        }
    }
}
