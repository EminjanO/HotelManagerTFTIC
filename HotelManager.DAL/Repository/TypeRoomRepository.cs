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
    class TypeRoomRepository : IRepository<TypeRoom, int>
    {
        public TypeRoom Get(int id)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command("SELECT * FROM type_room WHERE id = @id");
            cmd.AddParameter("@id", id);
            List<Dictionary<string, object>> type_rooms = Connection.ExecuteReader(cmd);
            return new TypeRoom
            {
                Id          = (int)     type_rooms[0]["id"],
                Type_name   = (string)  type_rooms[0]["type_name"],
                Capacity    = (int)     type_rooms[0]["capacity"],
                Kichen      = (bool)    type_rooms[0]["kitchen"],
                Tub         = (bool)    type_rooms[0]["tub"],
                Price       = (decimal) type_rooms[0]["price"],
                Created_at  = (DateTime)type_rooms[0]["created_at"],
                Last_update = (DateTime)type_rooms[0]["last_update"],
                IsActive    = (bool)    type_rooms[0]["isActive"]
            };
        }

        public IEnumerable<TypeRoom> GetAll()
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"SELECT * FROM type_room");
            List<Dictionary<string, object>> typeRoomsData = Connection.ExecuteReader(cmd);

            List<TypeRoom> TypeRooms = new List<TypeRoom>();

            foreach (Dictionary<string, object> TypeRoom in typeRoomsData)
            {
                TypeRooms.Add(new TypeRoom
                {
                    Id          = (int)     TypeRoom["id"],
                    Type_name   = (string)  TypeRoom["type_name"],
                    Capacity    = (int)     TypeRoom["capacity"],
                    Kichen      = (bool)    TypeRoom["kitchen"],
                    Tub         = (bool)    TypeRoom["tub"],
                    Price       = (decimal) TypeRoom["price"],
                    Created_at  = (DateTime)TypeRoom["created_at"],
                    Last_update = (DateTime)TypeRoom["last_update"],
                    IsActive    = (bool)    TypeRoom["isActive"]
                });
            }
            return TypeRooms;
        }

        public int Insert(TypeRoom entity)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"EXECUTE InsertTypeRoom @TypeRoom_name, @description");

            cmd.AddParameter("@TypeRoom_name", entity.TypeRoomName);
            cmd.AddParameter("@description", entity.Description);

            return Connection.ExecuteScalar<int>(cmd);
        }

        public bool Update(TypeRoom entity)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"UPDATE TypeRoom SET TypeRoom_name = @TypeRoom_name, description = @description WHERE id = @id");

            cmd.AddParameter("@id", entity.Id);
            cmd.AddParameter("@TypeRoom_name", entity.TypeRoomName);
            cmd.AddParameter("@description", entity.Description);

            return Connection.ExecuteNonQuery(cmd) == 0 ? false : true;
        }

        public bool Delete(TypeRoom entity)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command("DELETE TypeRoom WHERE id = @id");

            cmd.AddParameter("@id", entity.Id);

            return Connection.ExecuteNonQuery(cmd) == 0 ? false : true;
        }
    }
}
