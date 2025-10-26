using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MiniChatApp
{
    public interface IRepository<T> where T : Record
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        List<T> GetAll();
        T GetById(Guid id);
    }
}
