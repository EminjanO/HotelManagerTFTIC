using System.Collections.Generic;
using HotelManager.DAL.Entity;

namespace HotelManager.DAL.Interface
{
    public interface IGuestRepository : IRepository<Guest, int>
    {
        Guest Convert(Dictionary<string, object> Data);
        int Insert(Guest entity);
        bool Update(Guest entity);
    }
}