using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public class Manager : Staff
    {
        public Manager(string firstName, string lastName, string email, RoleStatus role, int experienceYear, string shiftSchedule, string department) : base(firstName, lastName, email, role, experienceYear, shiftSchedule)
        {
            Department = department;
        }
        public string Department { get; set; }
        public List<Staff> ManagedStaff { get; set; } = new List<Staff>();
    }
}
