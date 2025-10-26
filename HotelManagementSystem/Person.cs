using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public abstract class Person
    {
        private string _email;
        protected Person(string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Guid Id { get; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Email boş olamaz.");
                }
                else if (!value.Contains('@'))
                {
                    Console.WriteLine("Email formatında yazmalısınız");
                }
                else if (!value.Contains('.'))
                {
                    Console.WriteLine("Email formatında yazmalısınız");
                }
                else
                {
                    _email = value;
                }
            }
        }
        public override string ToString()
        {
            return $"Id: {Id} Name-Surname {FirstName} {LastName} Email: {Email}";
        }
    }
}
