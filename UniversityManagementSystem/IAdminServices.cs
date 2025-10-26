using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public interface IAdminServices
    {
        void AddTeacher(Guid adminId, Teacher teacher);
        List<Teacher> ManagedTeachers(Guid adminId);
    }
}
