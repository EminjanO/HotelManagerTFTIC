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
    public class ProfilRepository : BaseRepository<Profil, int>, IProfilRepository
    {
        public ProfilRepository(DBConnect db) : base(db)
        {

        }

        public override int Insert(Profil entity)
        {
            Command cmd = new Command($"EXECUTE InsertProfil @profil_name, @description");

            cmd.AddParameter("@profil_name", entity.ProfilName);
            cmd.AddParameter("@description", entity.Description);

            return DB.ExecuteScalar<int>(cmd);
        }

        public override bool Update(Profil entity)
        {
            Command cmd = new Command($"UPDATE profil SET profil_name = @profil_name, description = @description WHERE id = @id");

            cmd.AddParameter("@id", entity.Id);
            cmd.AddParameter("@profil_name", entity.ProfilName);
            cmd.AddParameter("@description", entity.Description);

            return DB.ExecuteNonQuery(cmd) == 0 ? false : true;
        }

        public override Profil Convert(Dictionary<string, object> Data)
        {
            return new Profil
            {
                Id          = (int)Data["id"],
                ProfilName  = (string)Data["profil_name"],
                Description = Data["description"]==DBNull.Value ? null : (string)Data["description"],
                IsActive    = (bool)Data["isActive"]
            };
        }
    }
}
