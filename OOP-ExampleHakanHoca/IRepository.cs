using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ExampleHakanHoca
{
    public interface IRepository <T> where T : Record
    {
        void Add(T item);
        void Update(T item);
        void Remove(Guid id);
        List<T> GetAll();
        T GetById(Guid id);
    }
}
