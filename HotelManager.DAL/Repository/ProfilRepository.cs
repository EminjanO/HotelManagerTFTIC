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
    public class ProfilRepository : IRepository<Profil,int>
    {
        Profil IRepository<Profil, int>.Get(int id)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command("SELECT * FROM profil WHERE id = @id");
            cmd.AddParameter("@id", id);
            List<Dictionary<string, object>> profils = Connection.ExecuteReader(cmd);
            return new Profil
            {
                Id          = (int)     profils[0]["id"],
                ProfilName  = (string)  profils[0]["profil_name"],
                Description = (string)  profils[0]["description"],
                IsActive    = (bool)    profils[0]["isActive"]
            };
        }

        IEnumerable<Profil> IRepository<Profil, int>.GetAll()
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"SELECT * FROM profil");
            List<Dictionary<string, object>> profilsData = Connection.ExecuteReader(cmd);

            List<Profil> profils = new List<Profil>();

            foreach (Dictionary<string, object> profil in profilsData)
            {
                profils.Add(new Profil
                {
                    Id          = (int)     profil["id"],
                    ProfilName  = (string)  profil["profil_name"],
                    Description = (string)  profil["description"],
                    IsActive    = (bool)    profil["isActive"]
                });
            }
            return profils;
        }

        public int Insert(Profil entity)
        {
                DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
                Command cmd = new Command($"EXECUTE InsertProfil @profil_name, @description");

                cmd.AddParameter("@profil_name", entity.ProfilName);
                cmd.AddParameter("@description", entity.Description);

                return Connection.ExecuteScalar<int>(cmd);
        }

        public bool Update(Profil entity)
        {
                DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
                Command cmd = new Command($"UPDATE profil SET profil_name = @profil_name, description = @description WHERE id = @id");

                cmd.AddParameter("@id", entity.Id);
                cmd.AddParameter("@profil_name", entity.ProfilName);
                cmd.AddParameter("@description", entity.Description);

                return Connection.ExecuteNonQuery(cmd) == 0 ? false : true;
        }

        public bool Delete(Profil entity)
        {
                DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
                Command cmd = new Command("DELETE profil WHERE id = @id");

                cmd.AddParameter("@id", entity.Id);

                return Connection.ExecuteNonQuery(cmd) == 0 ? false : true;
        }
    }
}
