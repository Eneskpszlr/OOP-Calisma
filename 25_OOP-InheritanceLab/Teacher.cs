using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_OOP_InheritanceLab
{
    public class Teacher : Person
    {
		private string _branch;
		private int _experience;
		private static int _id = 300;

        public Teacher(string firstName, string lastName, string email, string branch, int experience) : base(firstName, lastName, email)
        {
			Branch = branch;
			Experience = experience;
            Id = _id++;
        }
        public int Experience
		{
			get { return _experience; }
			set { _experience = value; }
		}
		public string Branch
		{
			get { return _branch; }
			set { _branch = value; }
		}
        public override string ToString()
        {
            return base.ToString() + $" Branşı: {Branch} Deneyimi: {Experience} ";
        }
    }
}
