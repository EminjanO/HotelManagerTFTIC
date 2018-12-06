using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Interface
{
    public interface IRepository<T, TKey> where TKey:struct
    {
        T Get(TKey id);
        IEnumerable<T> GetAll();
        int Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
