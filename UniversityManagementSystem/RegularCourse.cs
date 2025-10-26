using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public class RegularCourse : Course
    {
        public RegularCourse(string courseName, Guid teacherId) : base(courseName, teacherId)
        {
        }
    }
}
