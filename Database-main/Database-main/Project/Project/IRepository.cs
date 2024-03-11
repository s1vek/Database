using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface IRepository<T> where T : IBaseClass // Used for inherit methods for all DAO classes
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        int Insert(T element);
        void Update(T element);
        void Delete(int id);
        
    }
}
