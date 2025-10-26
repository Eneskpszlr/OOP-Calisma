using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MiniChatApp
{
    public class Repository<T> : IRepository<T> where T : Record
    {
        private static List<T> _repo = new List<T>();
        public void Add(T item)
        {
            _repo.Add(item);
        }
        public void Delete(T item)
        {
            _repo.Remove(item);
        }
        public List<T> GetAll()
        {
            return _repo;
        }
        public T GetById(Guid id)
        {
            foreach (T item in _repo)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public void Update(T item)
        {
            var found = _repo.FirstOrDefault(x => x.Id == item.Id);
            if (found != null)
            {
                _repo.Remove(found);
                _repo.Add(item);
            }
        }
    }
}
