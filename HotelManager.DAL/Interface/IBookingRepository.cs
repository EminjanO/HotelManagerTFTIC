using System.Collections.Generic;
using HotelManager.DAL.Entity;

namespace HotelManager.DAL.Interface
{
    public interface IBookingRepository : IRepository<Booking, int>
    {
        Booking Convert(Dictionary<string, object> Data);
        int Insert(Booking entity);
        bool Update(Booking entity);
    }
}