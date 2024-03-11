using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface IDAO<T> where T : IBaseClass
    {

        public T? GetByID(int id);
        public IEnumerable<T> GetAll();
        public void Save(T element);
        public void Delete(T element);

    }
}
