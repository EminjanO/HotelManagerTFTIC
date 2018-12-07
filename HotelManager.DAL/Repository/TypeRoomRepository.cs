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
    public class TypeRoomRepository : BaseRepository<TypeRoom, int>, ITypeRoomRepository
    {
        public TypeRoomRepository(DBConnect db) : base(db)
        {

        }

        public override int Insert(TypeRoom entity)
        {
            Command cmd = new Command($"INSERT INTO type_room (type_name, capacity, price, kitchen, tub) VALUES (@type_name, @capacity, @price, @kitchen, @tub)");

            cmd.AddParameter("@type_name", entity.Type_name);
            cmd.AddParameter("@capacity", entity.Capacity);
            cmd.AddParameter("@price", entity.Price);
            cmd.AddParameter("@kitchen", entity.Kichen);
            cmd.AddParameter("@tub", entity.Tub);

            return DB.ExecuteScalar<int>(cmd);
        }

        public override bool Update(TypeRoom entity)
        {
            Command cmd = new Command($"UPDATE TypeRoom SET type_name = @type_name, capacity = @capacity, price = @price, kitchen = @kitchen, tub = @tub, last_update = @last_update WHERE id = @id");

            cmd.AddParameter("@type_name", entity.Type_name);
            cmd.AddParameter("@capacity", entity.Capacity);
            cmd.AddParameter("@price", entity.Price);
            cmd.AddParameter("@kitchen", entity.Kichen);
            cmd.AddParameter("@tub", entity.Tub);
            cmd.AddParameter("@last_update", DateTime.Now);

            return DB.ExecuteNonQuery(cmd) == 0 ? false : true;
        }

        public override TypeRoom Convert(Dictionary<string, object> Data)
        {
            return new TypeRoom
            {
                Id = (int)Data["id"],
                Type_name = (string)Data["type_name"],
                Capacity = (int)Data["capacity"],
                Kichen = (bool)Data["kitchen"],
                Tub = (bool)Data["tub"],
                Price = (decimal)Data["price"],
                Created_at = (DateTime)Data["created_at"],
                Last_update = (DateTime)Data["last_update"],
                IsActive = (bool)Data["isActive"]
            };
        }
    }
}
