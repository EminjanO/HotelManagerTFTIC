using HotelManager.DAL.Entity;
using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolDataBase;

namespace HotelManager.DAL.Repository
{
    public class UserRepository : IRepository<User, int>
    {
        public User Get(int id)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command("SELECT * FROM [user] WHERE id = @id");
            cmd.AddParameter("@id", id);
            List<Dictionary<string, object>> Users = Connection.ExecuteReader(cmd);
            return new User
            {
                Id          = (int)     Users[0]["id"],
                FirstName   = (string)  Users[0]["firstname"],
                LastName    = (string)  Users[0]["lastname"],
                CreatedAt  = (DateTime) Users[0]["created_at"],
                LastUpdate = (DateTime) Users[0]["last_update"],
                IsActive    = (bool)    Users[0]["isActive"],
                Id_profil   = (int)     Users[0]["id_profil"]
            };
        }

        public IEnumerable<User> GetAll()
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"SELECT * FROM [user]");
            List<Dictionary<string, object>> UsersData = Connection.ExecuteReader(cmd);

            List<User> Users = new List<User>();

            foreach (Dictionary<string, object> User in UsersData)
            {
                Users.Add(new User
                {
                    Id          = (int)     User["id"],
                    FirstName   = (string)  User["firstname"],
                    LastName    = (string)  User["lastname"],
                    CreatedAt   = (DateTime)User["created_at"],
                    LastUpdate  = (DateTime)User["last_update"],
                    IsActive    = (bool)    User["isActive"],
                    Id_profil   = (int)     User["id_profil"]
                });
            }
            return Users;
        }

        public int Insert(User entity)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"EXECUTE InsertUser @firstname, @lastname, @id_profil");

            cmd.AddParameter("@User_name",      entity.FirstName);
            cmd.AddParameter("@description",    entity.LastName);
            cmd.AddParameter("@description",    entity.Id_profil);

            return Connection.ExecuteScalar<int>(cmd);
        }

        public bool Update(User entity)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"UPDATE [user] SET firstname = @firstname, lastname = @lastname, id_profil = @id_profil, last_update = {DateTime.Now} WHERE id = @id");

            cmd.AddParameter("@User_name",      entity.FirstName);
            cmd.AddParameter("@description",    entity.LastName);
            cmd.AddParameter("@description",    entity.Id_profil);

            return Connection.ExecuteNonQuery(cmd) == 0 ? false : true;
        }

        public bool Delete(User entity)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command("DELETE [user] WHERE id = @id");

            cmd.AddParameter("@id", entity.Id);

            return Connection.ExecuteNonQuery(cmd) == 0 ? false : true;
        }
    }
}
