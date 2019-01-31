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
    //todo : Géré les null pour add_info pour Insert() et Update()

    public class GuestRepository : BaseRepository<Guest, int>, IGuestRepository
    {
        public GuestRepository(DBConnect db) : base (db)
        {

        }

        public override Guest Convert(Dictionary<string, object> Data)
        {
            return new Guest
            {
                Id = (int)Data["id"],
                FirstName = (string)Data["firstname"],
                LastName = (string)Data["lastname"],
                Email = (string)Data["email"],
                Phone = (string)Data["phone"],
                Add_info = Data["add_info"] == DBNull.Value ? null : (string)Data["add_info"],
                Created_at = (DateTime)Data["created_at"],
                Last_update = (DateTime)Data["last_update"],
                IsActive = (bool)Data["isActive"]
            };
        }

        
        public override int Insert(Guest entity)
        {
            var addinfo = entity.Add_info == null ? "NULL" : "'" + entity.Add_info + "'";
            Command cmd = new Command($"EXECUTE InsertGuest @firstname, @lastname, @email, @phone, {addinfo}");

            cmd.AddParameter("@firstname", entity.FirstName);
            cmd.AddParameter("@lastname", entity.LastName);
            cmd.AddParameter("@email", entity.Email);
            cmd.AddParameter("@phone", entity.Phone);

            return DB.ExecuteScalar<int>(cmd);
        }

        public override bool Update(Guest entity)
        {
            Command cmd = new Command($"UPDATE guest SET firstname = @firstname, lastname = @lastname , email = @email, phone = @phone, add_info = @add_info, last_update = '{DateTime.Now}' WHERE id = @id");

            cmd.AddParameter("@id", entity.Id);
            cmd.AddParameter("@firstname", entity.FirstName);
            cmd.AddParameter("@lastname", entity.LastName);
            cmd.AddParameter("@email", entity.Email);
            cmd.AddParameter("@phone", entity.Phone);
            cmd.AddParameter("@add_info", entity.Add_info );

            return DB.ExecuteNonQuery(cmd) == 0 ? false : true;
        }
    }
}
