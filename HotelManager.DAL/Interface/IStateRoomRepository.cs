using System.Collections.Generic;
using HotelManager.DAL.Entity;

namespace HotelManager.DAL.Interface
{
    public interface IStateRoomRepository : IRepository<StateRoom, int>
    {
        StateRoom Convert(Dictionary<string, object> Data);
        int Insert(StateRoom entity);
        bool Update(StateRoom entity);
    }
}