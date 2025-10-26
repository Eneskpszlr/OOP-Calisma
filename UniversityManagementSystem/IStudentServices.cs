using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public interface IStudentServices
    {
        string RegisterStudent(Student student);
        List<Student> GetAllStudents();
        List<Course> GetStudentCourses(Guid studentId);
        string RegStudentToCourse(Guid studentId, Guid courseId);
        Student LoginStudent(string email);
    }
}
