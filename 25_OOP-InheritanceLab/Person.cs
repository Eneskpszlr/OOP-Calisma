using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_OOP_InheritanceLab
{
    public class Person
    {
		private string _firstName;
		private string _lastName;
		private string _email;
		protected int _id;

        public Person(string firstName, string lastName, string email)
        {
			FirstName = firstName;
			LastName = lastName;
			Email = email;
        }
        public int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}
		public string FullName => _firstName + " " + _lastName;
		public override string ToString()
		{
			return $"\nId: {Id} Ad-Soyad: {FullName} Email: {Email} ";
		}
	}
}
