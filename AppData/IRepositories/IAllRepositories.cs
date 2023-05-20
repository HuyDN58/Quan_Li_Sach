using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepositories
{
    public interface IAllRepositories<T>
    {
        public IEnumerable<T> GetAll();
        public bool CreateItem(T item);
        public bool DeleteItem(T item);
        public bool UpdateItem(T item);

    }
}
