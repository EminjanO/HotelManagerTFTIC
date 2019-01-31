using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class IndexBookingVM
    {
        public List<BookingVM> bookingVMs { get; set; }
        public List<RoomTypeVM> roomtypeVMs { get; set; }
    }
}