using System.Collections.Generic;
using HotelManager.DAL.Entity;

namespace HotelManager.DAL.Interface
{
    public interface ITypeRoomRepository : IRepository<TypeRoom, int>
    {
        TypeRoom Convert(Dictionary<string, object> Data);
        int Insert(TypeRoom entity);
        bool Update(TypeRoom entity);
    }
}