using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Entity
{
    public class STBookingGuest : IEntity<int>
    {
        public int BookingId { get; set; }
        public int Userid { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public bool BookingHasPayed { get; set; }
        public bool BookingIsCreated { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string BookingInfo { get; set; }
        public int NbPerson { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public string Email { get; set; }
        public string GuestPhone { get; set; }
        public string GuestInfo { get; set; }

        public int Id
        {
            get { return BookingId; }
            set { BookingId = value; }
        }
    }
}
