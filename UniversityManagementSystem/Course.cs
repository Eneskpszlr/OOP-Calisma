using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public abstract class Course
    {
        protected Course(string courseName, Guid teacherId)
        {
            CourseCode = Guid.NewGuid();
            CourseName = courseName;
            TeacherId = teacherId;
            RegisteredStudents = new List<Student>();
        }

        public Guid CourseCode { get; set; }
        public string CourseName { get; set; }
        public Guid TeacherId { get; set; }
        public List<Student> RegisteredStudents { get; set; }
        public void AddStudent(Student student)
        {
            RegisteredStudents.Add(student);
        }
        public override string ToString()
        {
            return $"Course Code: {CourseCode} Course Name: {CourseName} TeacherId: {TeacherId}";
        }
    }
}
