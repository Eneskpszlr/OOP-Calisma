using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public enum RoleStatus
    {
        Dean, DepartmentHead, Secretary
    }
    public class Admin : Person
    {
        public List<Teacher> ManagedTeachers { get; set; } = new List<Teacher>();
        public RoleStatus Role { get; private set; }
        public Admin(string firstName, string lastName, string email, RoleStatus role) : base(firstName, lastName, email)
        {
            Role = role;
        }
        public void AddTeacher(Teacher teacher)
        {
            if (!ManagedTeachers.Contains(teacher))
            {
                ManagedTeachers.Add(teacher);
            }
        }

        public List<Teacher> ListManagedTeachers()
        {
            return ManagedTeachers;
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Role: {Role}";
        }
    }
}
