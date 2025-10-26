using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public enum RoleStatus
    {
        Recepcionist, Cleaner, Manager
    }
    public class Staff : Person
    {
        private int _experienceYear;
        public Staff(string firstName, string lastName, string email, RoleStatus role, int experienceYear, string shiftSchedule) : base(firstName, lastName, email)
        {
            Role = role;
            ExperienceYear = experienceYear;
            ShiftSchedule = shiftSchedule;
        }

        public RoleStatus Role { get; set; }
        public int ExperienceYear 
        {
            get
            {
                return _experienceYear;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Deneyim yılı 0'dan küçük olamaz.");
                }
                else
                {
                    _experienceYear = value;
                }
            }
        }
        public string ShiftSchedule { get; set; }
    }
}
