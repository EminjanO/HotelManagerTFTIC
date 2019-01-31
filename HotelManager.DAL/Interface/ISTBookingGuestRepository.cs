using System.Collections.Generic;
using HotelManager.DAL.Entity;

namespace HotelManager.DAL.Interface
{
    public interface ISTBookingGuestRepository
    {
        STBookingGuest Convert(Dictionary<string, object> Data);
        int Insert(STBookingGuest entity);
        bool Update(STBookingGuest entity);
    }
}