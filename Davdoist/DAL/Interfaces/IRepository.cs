using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();

        public T GetById(int id);

        public void Delete(int id);

        public void Delete(T entity);

        public void Add(T entity);

        public void Update(int id);
    }
}
