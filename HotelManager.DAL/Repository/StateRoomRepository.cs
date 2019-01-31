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
    public class StateRoomRepository : BaseRepository<StateRoom, int>, IStateRoomRepository
    {
        public StateRoomRepository(DBConnect db) : base(db){}
        public override StateRoom Convert(Dictionary<string, object> Data)
        {
            return new StateRoom
            {
                Id = (int)Data["id"],
                State_name = (string)Data["state_name"],
                Created_at = (DateTime)Data["created_at"],
                Last_update = (DateTime)Data["last_update"]
            };
        }

        public override int Insert(StateRoom entity)
        {
            Command cmd = new Command($"INSERT INTO state_room (state_name) VALUES (@state_name)");

            cmd.AddParameter("@state_name", entity.State_name);

            return DB.ExecuteScalar<int>(cmd);
        }

        public override bool Update(StateRoom entity)
        {
            Command cmd = new Command($"UPDATE state_room SET state_name = @state_name, last_update = @last_update WHERE id = @id");

            cmd.AddParameter("@state_name", entity.State_name);
            cmd.AddParameter("@last_update", DateTime.Now);

            return DB.ExecuteNonQuery(cmd) == 0 ? false : true;
        }
    }
}
