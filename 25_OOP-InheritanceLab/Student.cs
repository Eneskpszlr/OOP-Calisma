using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_OOP_InheritanceLab
{
    public class Student : Person
    {
        private int _studentNo;
        private static int _id = 100;

        public Student(string firstName, string lastName, string email, int studentNo) : base(firstName, lastName, email)
        {
            StudentNo = studentNo;
            Id = _id++;
        }
        public List<int> Not = new List<int>();
        public int StudentNo
        {
            get { return _studentNo; }
            set { _studentNo = value; }
        }
        public void NotEkle(int sayi)
        {
            if (sayi < 100 && sayi >= 0)
                Not.Add(sayi);
            else
                Console.WriteLine("Geçersiz sayı girdiniz.");
        }
        public int CalculateAverage()
        {
            int sum = 0;
            foreach (var item in Not)
            {
                sum += item;
            }
            return sum/Not.Count;
        }
        public override string ToString()
        {
            return base.ToString() + $" Öğrenci Numarası: {StudentNo} ";
        }
    }
}
