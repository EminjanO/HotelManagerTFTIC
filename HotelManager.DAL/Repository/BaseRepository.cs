using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace HotelManager.DAL.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        private string _tableName;
        private DBConnect _db;

        public DBConnect DB
        {
            get { return _db; }
            private set { _db = value; }
        }

        public string TableName
        {
            get { return _tableName; }
            private set { _tableName = value; }
        }

        public BaseRepository(DBConnect db)
        {
            this.DB = db;
            string name = typeof(TEntity).Name;
            if (name.Contains("Room") && name.Length > 4)
            {
                string separator = "_";
                this.TableName = name.Substring(0, name.Length - 4) + separator + "room";
            }
            else
            {
                this.TableName = name;
            }
        }
        #region Delete
        public virtual bool Delete(TKey id)
        {
            Command cmd = new Command($"DELETE FROM [{TableName}] WHERE id = @id");
            cmd.AddParameter("@id", id);
            return DB.ExecuteNonQuery(cmd) == 0 ? false : true;
        }
        public virtual bool Delete(TEntity entity)
        {
            return Delete(entity.Id);
        }
        #endregion
        #region Gets
        public virtual TEntity Get(TKey id)
        {
            Command cmd = new Command($"SELECT * FROM [{TableName}] WHERE id = @id");

            cmd.AddParameter("@id", id);

            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            if (datas.Count == 1)
            {
                return Convert(datas[0]);
            }

            return default(TEntity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            Command cmd = new Command($"SELECT * FROM [{TableName}]");
            List<Dictionary<string, object>> results = DB.ExecuteReader(cmd);

            List<TEntity> datas = new List<TEntity>();

            foreach (Dictionary<string, object> data in results)
            {
                datas.Add(Convert(data));
            }

            return datas;
        }
        #endregion
        #region Insert/Update/Convert
        public abstract int Insert(TEntity entity);
        public abstract bool Update(TEntity entity);
        public abstract TEntity Convert(Dictionary<string, object> Data);
        #endregion
    }
}
