using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public interface ITeacherServices
    {
        void RegisterTeacher(Teacher teacher);
        void AssignCourse(Guid teacherId, Guid courseId);
        List<Course> GetTeacherCourses(Guid teacherId);
    }
}
