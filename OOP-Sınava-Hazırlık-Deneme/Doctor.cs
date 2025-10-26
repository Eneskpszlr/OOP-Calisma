using OOP_Sınava_Hazırlık_Deneme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Sınava_Hazırlık_Deneme
{
    public class Doctor : Person , ISchedulable , ISaveable
    {
        public string Speciliality { get; set; }
        public int ExperienceYear { get; set; }

        public List<Patient> Patients { get; set;  } = new();

        public Doctor(string firstName, string lastName, string email, string speciliality, int experienceYear) :
            base(firstName , lastName , email)
        {
            Speciliality = speciliality;
            ExperienceYear = experienceYear;
        }

        public void AddPatient(Patient p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            if (Patients.Contains(p)) throw new Exception("Hasta zaten kayıtlı.");
            Patients.Add(p);
        }

        public void Save()
        {
            Console.WriteLine("Doctor başarıyla kaydedildi.");
        }

        public void ScheduleShift(string date) => Console.WriteLine($"{FirstName} için vardiya: {date}");

        public override string ToString()
        {
            return $"Id: {Id} Ad-Soyad: {FirstName} {LastName} Maili: {Email} Branşı: {Speciliality} Deneyim Yılı: {ExperienceYear} ";
        }
    }
}
