using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public class Student : Person
    {
        public Student(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            StudentNo++;
        }
        public static int StudentNo { get; private set; } = 1000;
        public List<Course> ToCourseList { get; set; } = new List<Course>();

        public void EnrollInCourse(Course course)
        {
            if (!ToCourseList.Contains(course))
            {
                ToCourseList.Add(course);
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"StudentNo: {StudentNo}";
        }
    }
}
