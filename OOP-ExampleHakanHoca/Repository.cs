using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ExampleHakanHoca
{
    public class Repository<T> : IRepository<T> where T : Record
    {
        private static List<T> _depo = new List<T>();

        public void Add(T item)
        {
            _depo.Add(item);
        }

        public List<T> GetAll()
        {
            return new List<T>(_depo);
        }

        public T GetById(Guid id)
        {
            return _depo.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Guid id)
        {
            var existing = GetById(id);
            if (existing == null)
                throw new Exception("Kayıtlı id bulunamadı.");
            _depo.Remove(existing);
        }

        public void Update(T item)
        {
            var existing = GetById(item.Id);
            if (existing == null)
                throw new Exception("Kayıtlı id bulunamadı.");
            _depo.Remove(existing);
            _depo.Add(item);
        }
    }
}
