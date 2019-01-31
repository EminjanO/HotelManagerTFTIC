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
    public class RoomRepository : BaseRepository<Room, int>, IRoomRepository
    {
        public RoomRepository(DBConnect db) : base(db) { }
        public override Room Convert(Dictionary<string, object> Data)
        {
            return new Room
            {
                Id = (int)Data["id"],
                Num = (string)Data["num"],
                Add_info = Data["add_info"] == DBNull.Value ? null : (string)Data["add_info"],
                Created_at = (DateTime)Data["created_at"],
                Last_update = (DateTime)Data["last_update"],
                IsActive = (bool)Data["isActive"],
                Id_state_room = (int)Data["id_state_room"],
                Id_type_room = (int)Data["id_type_room"]
            };
        }

        public override int Insert(Room entity)
        {
            Command cmd = new Command($"EXECUTE InsertRoom @num, @add_info, @id_type_room, @id_state_room");
            cmd.AddParameter("@num", entity.Num);
            cmd.AddParameter("@add_info", entity.Add_info);
            cmd.AddParameter("@id_type_room", entity.Id_type_room);
            cmd.AddParameter("@id_state_room", entity.Id_state_room);

            return DB.ExecuteScalar<int>(cmd);
        }

        public override bool Update(Room entity)
        {
            Command cmd = new Command($"UPDATE [booking] SET num = @num, add_info = @add_info, id_type_room = @id_type_room, id_state_room = @id_state_room, last_update = {DateTime.Now} WHERE id = @id");
            cmd.AddParameter("@num", entity.Num);
            cmd.AddParameter("@add_info", entity.Add_info);
            cmd.AddParameter("@id_type_room", entity.Id_type_room);
            cmd.AddParameter("@id_state_room", entity.Id_state_room);

            return DB.ExecuteNonQuery(cmd) == 0 ? false : true;
        }
    }
}