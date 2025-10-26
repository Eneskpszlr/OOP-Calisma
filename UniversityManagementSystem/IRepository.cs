using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(Guid id);
        void Delete(Guid id);
        List<T> GetAll();
        T GetById(Guid id);
    }
}
