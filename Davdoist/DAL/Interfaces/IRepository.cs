using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IRepository<T> where T : class
    {
        public T Read();

        public void Delete(T instance);

        public void Add(T instance);

        public void Update();
    }
}
