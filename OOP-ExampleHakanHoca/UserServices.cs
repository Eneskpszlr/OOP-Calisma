using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ExampleHakanHoca
{
    public class UserServices : IUserServices
    {
        private Repository<User> userlist = new Repository<User>();
        private User _activeUser = null;

        public List<User> GetAllUsers() => userlist.GetAll();

        public User GetActiveUser()
        {
            return _activeUser;
        }

        public string Login(string username, string password)
        {
            var users = userlist.GetAll();
            var found = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (found == null)
                return "Hatalı giriş yaptınız.";
            else
                _activeUser = found;
            return $"Hoş geldiniz. {found.FirstName}";
        }

        public void Logout(User user)
        {
            _activeUser = null;
            Console.WriteLine("Çıkış yapıldı.");
        }

        public string Register(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (userlist.GetAll().Any(u => u.Username == user.Username))
                return "Bu kullanıcı adı zaten kayıtlı.";

            userlist.Add(user);
            return $"Kayıt başarılı: {user.Username}";
        }
    }
}
