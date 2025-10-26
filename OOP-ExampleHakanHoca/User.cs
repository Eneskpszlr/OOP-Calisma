using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ExampleHakanHoca
{
    public class User : Record
    {
		private string _username;
		private string _firstName;
		private string _lastName;
		private string _email;
		private string _password;

        public User(string username, string firstName, string lastName, string email, string password)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        public string Password
		{
			get { return _password; }
			set 
			{
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password null olamaz.");
                }
                if (value.Length < 8)
                {
                    _password = value.PadRight(8, '*');
                }
                else
                {
                    _password = value;
                }
            }
		}
		public string EmailConfirm => Email;
		public string Email
		{
			get { return _email; }
			set 
			{
				if (value != null)
				{
					_email = value;
				}
				else
					throw new ArgumentException("Email boş olamaz.");
			}
		}
		public string LastName
		{
			get { return _lastName; }
			set 
			{
                if (value != null)
                {
                    _lastName = value;
                }
                else
                    throw new ArgumentException("Lastname boş olamaz.");
            }
		}
		public string FirstName
		{
			get { return _firstName; }
            set
            {
                if (value != null)
                {
                    _firstName = value;
                }
                else
                    throw new ArgumentException("Firstname boş olamaz.");
            }
        }
		public string Username
		{
			get 
			{ 
				return _username; 
			}
			set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Username null olamaz.");
				}
				if (value.Length < 3)
				{
                    _username = value.PadLeft(3, '*');
                }
				else if (value.Length > 20)
				{
                    _username = value.Substring(0,20);
                }
				else
				{
					_username = value;
				}  
			}
		}
        public override string ToString()
        {
            return base.ToString() + $"Username: {Username} Email: {Email}";
        }
	}
}
