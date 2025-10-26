using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Sınava_Hazırlık_Deneme
{
    public class Patient : Person , ISaveable
    {
        public Patient(string firstName, string lastName, string email, string illness) : base(firstName, lastName, email)
        {
            Illness = illness;
        }

        public string Illness { get; set; }
        public List<Doctor> AssignedDoctor { get; set; } = new List<Doctor>();

        public void AddAssignedDoctor(Doctor d)
        {
            if (d == null) throw new ArgumentNullException(nameof(d));
            if (!AssignedDoctor.Contains(d)) AssignedDoctor.Add(d);
        }

        public void GetTreatment()
        {
            Console.WriteLine($"{FirstName} {LastName} tedavi alındı.");
        }

        public void Save()
        {
            Console.WriteLine("Patient başarıyla kaydedildi.");
        }

        public override string ToString()
        {
            return $"Id: {Id} Ad-Soyad: {FirstName} {LastName} Maili: {Email} Hastalığı: {Illness}";
        }
    }
}
