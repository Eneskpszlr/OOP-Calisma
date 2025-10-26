using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public class Repository<T> : IRepository<T> where T : Person
    {
        private readonly List<T> _repo = new List<T>();
        public void Add(T entity)
        {
            _repo.Add(entity);
        }
        public void Delete(Guid id)
        {
            var item = _repo.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _repo.Remove(item);
            }
            else
            {
                Console.WriteLine("Silinecek bir şey yok.");
            }
        }
        public List<T> GetAll()
        {
            return _repo;
        }
        public T GetById(Guid id)
        {
            return _repo.FirstOrDefault(x => x.Id == id);
        }
        public void Update(Guid id)
        {
            var item = _repo.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _repo.Remove(item);
                _repo.Add(item);
            }
            else
            {
                Console.WriteLine("Güncellenecek bir şey yok.");
            }
        }
    }
}
