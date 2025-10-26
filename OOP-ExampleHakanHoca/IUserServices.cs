using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ExampleHakanHoca
{
    public interface IUserServices
    {
        string Register(User user);
        string Login (string username, string password);
        void Logout(User user);

        List<User> GetAllUsers();
    }
}
