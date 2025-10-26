using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Sınava_Hazırlık_Deneme
{
    public abstract class Person : ISaveable
    {
        private static int _personCounter = 100;
        protected Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Id = _personCounter++;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public abstract string ToString();

        public void Save()
        {
            Console.WriteLine("Person başarıyla kaydedildi.");
        }
        
    }
}
