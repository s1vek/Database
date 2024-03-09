using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface IRepository<T> where T : IBaseClass
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Insert(T element);
        void Update(T element);
        void Delete(T element);
    }
}
