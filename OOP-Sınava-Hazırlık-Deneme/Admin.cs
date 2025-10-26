using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Sınava_Hazırlık_Deneme
{
    public class Admin : Person , ISaveable
    {
        public string Department { get; set; }

        public List<Person> ManagedPerson = new List<Person>();

        public Admin(string firstName, string lastName, string email, string department) : base(firstName, lastName, email)
        {
            Department = department;
        }

        public void AddManageStaff(Person person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));
            if (person is Patient) throw new Exception("Patient cannot be managed.");
            if (!ManagedPerson.Contains(person)) ManagedPerson.Add(person);
        }
        public override string ToString()
        {
            return $"Id: {Id} Ad-Soyad: {FirstName} {LastName} Maili: {Email} Departmanı: {Department} ";
        }

        public void Save()
        {
            Console.WriteLine("Admin başarıyla kaydedildi.");
        }
    }
}
