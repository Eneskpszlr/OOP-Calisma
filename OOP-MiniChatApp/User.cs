using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MiniChatApp
{
    public class User : Record
    {
		private string _username;
		private string _password;
		private string _email;
		private string _firstName;
		private string _lastName;

        public User(string username, string password, string email, string firstName, string lastName)
        {
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
        public string LastName
		{
            get
            {
                return _lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
                _lastName = value;
            }
        }
		public string FirstName
		{
            get
            {
                return _firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
                _firstName = value;
            }
        }
        public string EmailConfirm => Email;
        public string Email
		{
            get
            {
                return _email;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
                if (!value.Contains("@"))
                    throw new ArgumentException("mail formatında yazmanız gerekmektedir.");
                _email = value;
            }
        }
		public string Password
		{
            get
            {
                return _password;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
                if (value.Length < 8)
                    throw new ArgumentException("Şifre 8 haneden az olamaz");
                _password = value;
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
					throw new ArgumentNullException(nameof(value));
				if (value.Length < 3)
					value = value.PadLeft(3, '*');
				if(value.Length > 20)
					value = value.Substring(0, 20);
				_username = value;
			}
		}
	}
}
