using System.Collections.Generic;
using HotelManager.DAL.Entity;

namespace HotelManager.DAL.Interface
{
    public interface IRoomRepository : IRepository<Room, int>
    {
        Room Convert(Dictionary<string, object> Data);
        int Insert(Room entity);
        bool Update(Room entity);
    }
}