using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public class Teacher : Person
    {
        private int _experienceYear;

        public int ExperienceYear
        {
            get 
            { 
                return _experienceYear; 
            }
            set 
            { 
                if(value < 0)
                {
                    throw new ArgumentException("Deneyim 0'dan küçük olamaz");
                }
                else
                {
                    _experienceYear = value;
                }
            }
        }
        public string Department { get; set; }
        public List<Course> GivenCourses { get; set; } = new List<Course> { };
        public Teacher(string firstName, string lastName, string email, string department, int experienceYear) : base(firstName, lastName, email)
        {
            Department = department;
            ExperienceYear = experienceYear;
        }
    }
}
