using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DAL.Interface;

namespace HotelManager.DAL.Interface
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        int Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(TKey id);
    }
}
