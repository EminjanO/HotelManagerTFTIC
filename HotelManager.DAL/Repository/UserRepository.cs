using HotelManager.DAL.Entity;
using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace HotelManager.DAL.Repository
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DBConnect db) : base(db) { }
        public override int Insert(User entity)
        {
            Command cmd = new Command($"EXECUTE AddUser @firstname, @lastname, @id_profil, @email, @password");
            cmd.AddParameter("@firstname", entity.FirstName);
            cmd.AddParameter("@lastname", entity.LastName);
            cmd.AddParameter("@id_profil", entity.Id_profil);
            cmd.AddParameter("@email", entity.Email);
            cmd.AddParameter("@password", entity.HashPassword);

            return DB.ExecuteScalar<int>(cmd);
        }

        public User CheckUser(string email, string password)
        {
            Command cmd = new Command($"EXECUTE CheckUser @email, @password");
            cmd.AddParameter("@email", email);
            cmd.AddParameter("@password", password);

            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            if (datas.Count == 1)
            {
                return Convert(datas[0]);
            }

            return default(User);
        }


        public override bool Update(User entity)
        {
            Command cmd = new Command($"UPDATE [user] SET firstname = @firstname, lastname = @lastname, id_profil = @id_profil, last_update = {DateTime.Now} WHERE id = @id");

            cmd.AddParameter("@firstname", entity.FirstName);
            cmd.AddParameter("@lastname", entity.LastName);
            cmd.AddParameter("@id_profil", entity.Id_profil);

            return DB.ExecuteNonQuery(cmd) == 0 ? false : true;
        }

        public override User Convert(Dictionary<string, object> Data)
        {
            return new User
            {
                Id = (int)Data["id"],
                FirstName = (string)Data["firstName"],
                LastName = (string)Data["lastName"],
                CreatedAt = (DateTime)Data["create_date"],
                LastUpdate = (DateTime)Data["last_update"],
                IsActive = (bool)Data["isActive"],
                Id_profil = (int)Data["id_profil"],
                Email = (string)Data["Email"],
                HashPassword = null
            };
        }
    }
}
