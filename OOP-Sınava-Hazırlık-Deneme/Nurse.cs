using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Sınava_Hazırlık_Deneme
{
    public class Nurse : Person , ISchedulable, ISaveable
    {
        public Nurse(string firstName, string lastName, string email, string department, string shift) : 
            base(firstName, lastName, email)
        {
            Department = department;
            Shift = shift;
        }

        public string Department { get; set; }
        public string Shift { get; set; }
        public List<Doctor> AssistDoctor { get; set; } = new List<Doctor>();

        public void AddAssistDoctor(Doctor d)
        {
            if (d == null) throw new ArgumentNullException(nameof(d));
            if (!AssistDoctor.Contains(d)) AssistDoctor.Add(d);
        }

        public void Save()
        {
            Console.WriteLine("Nurse Başarıyla Kaydedildi.");
        }

        public void ScheduleShift(string date) => Console.WriteLine($"{FirstName} için vardiya: {date}");

        public override string ToString()
        {
            return $"Id: {Id} Ad-Soyad: {FirstName} {LastName} Maili: {Email} Departmanı: {Department} Shifti: {Shift} ";
        }
    }
}
