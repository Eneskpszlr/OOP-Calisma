using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public abstract class Person
    {
        private string _email;

        protected Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public Guid Id { get; set; }
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
                    throw new ArgumentNullException("email boş olamaz");
                }
                else if (value.Contains('@') && value.Contains(".com"))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Maili mail formatında girmelisiniz.");
                }
            }
        }
        public DateTime CreatedDate { get; set; }


        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Email: {Email} Created Date: {CreatedDate}";
        }
    }
}
