using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public interface ICourseServices
    {
        string CreateCourse(Course course);
        List<Course> GetAllCourses();
        string GetCourseDetails(Guid courseId);
    }
}
