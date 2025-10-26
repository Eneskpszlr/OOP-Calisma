using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_OOP_InheritanceLab
{
    public enum Role
    {
        Müdür, MüdürYardımcısı
    }
    public class Manager : Person
    {
        private static int _id = 600;
		public List<Person> yonetilenKisiler {  get; set; } = new List<Person>();
        public Manager(string firstName, string lastName, string email, Role role) : base(firstName, lastName, email)
        {
			Role = role;
            Id = _id++;
        }
        public Role Role { get; private set; }

        public void KisiEkle(Person kisi) => yonetilenKisiler.Add(kisi);
        public override string ToString()
        {   
            string info = base.ToString() + $" Pozisyonu: {Role} ";
            if (yonetilenKisiler.Count > 0)
            {
                info += "\n  Yönettiği Kişiler:";
                foreach (var p in yonetilenKisiler)
                {
                    info += $"\n   - {p.FullName} ({p.Email})";
                }
            }
            else
            {
                info += "\n  Yönettiği kişi bulunmuyor.";
            }
            return info;
        }

        // Otomatik ilişki kurmak için yardımcı metot
        public static void IliskileriKur(List<Person> tumKisiler)
        {
            // 1. Müdürü bul
            var mudur = tumKisiler.OfType<Manager>().FirstOrDefault(m => m.Role == Role.Müdür);
            // 2. Tüm Müdür Yardımcılarını bul
            var yardimcilar = tumKisiler.OfType<Manager>().Where(m => m.Role == Role.MüdürYardımcısı).ToList();
            // 3. Tüm öğretmenleri bul
            var ogretmenler = tumKisiler.OfType<Teacher>().ToList();

            // Müdür → Müdür yardımcılarını yönetir
            if (mudur != null)
            {
                foreach (var y in yardimcilar)
                    mudur.yonetilenKisiler.Add(y);
            }
            // Müdür Yardımcıları → Öğretmenleri yönetir
            foreach (var y in yardimcilar)
            {
                foreach (var o in ogretmenler)
                    y.yonetilenKisiler.Add(o);
            }
        }
    }
}
