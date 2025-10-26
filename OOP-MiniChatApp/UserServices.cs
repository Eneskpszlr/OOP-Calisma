using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MiniChatApp
{
    public class UserServices : IUserServices
    {
        private Repository<User> userList = new Repository<User>();
        private User _activeUser = null;

        public List<User> GetAllUsers() => userList.GetAll();
        public string Login(string username, string password)
        {
            var found = userList.GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);
            if (found != null)
            {
                _activeUser = found;
                return $"Tebrikler! {_activeUser.Username} Başarıyla giriş yaptınız.";
            }
            else
                return "Kullanıcı adı ya da şifre hatalı";
        }
        public string Logout()
        {
            _activeUser = null;
            return "Başarıyla çıkış yaptınız.";
        }

        public string Register(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "Kullanıcı boş olamaz.");

            var username = user.Username?.Trim();

            if (userList.GetAll().Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                return "Bu kullanıcı adı zaten mevcut.";

            // Alan validasyonları
            if (string.IsNullOrWhiteSpace(user.Email))
                return "Email boş olamaz.";
            if (user.Password.Length < 8)
                return "Şifre en az 8 karakter olmalı.";

            // Kayıt işlemi
            userList.Add(user);
            return "Kullanıcı kaydı başarıyla tamamlandı.";
        }

        //public string Register(User user)
        //{
        //    if(user == null) 
        //        throw new ArgumentNullException("Kullanıcı boş olamaz");
        //    if (userList.GetAll().Any(u => u.Username == user.Username))
        //        throw new Exception("Kullanıcı adı kullanılıyor.");
        //    //var existing = userList.GetAll().FirstOrDefault(u => u.Username == user.Username);
        //    //if (existing != null)
        //    //    throw new Exception("Kullanıcı adı kullanılıyor.");
        //    userList.Add(user);
        //    return "Kullanıcı kaydı başarıyla tamamlandı.";
        //}

        public User GetActiveUser()
        {
            return _activeUser;
        }
    }
}
