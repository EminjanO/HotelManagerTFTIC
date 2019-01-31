using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.API.Models
{
    public class STBookingGuest
    {
        public int Id { get; set; }
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

        public STBookingGuest()
        {
            Id = -1;
        }

        public STBookingGuest(int userid, int roomId, int guestId, bool bookingHasPayed, bool bookingIsCreated, DateTime checkIn, DateTime checkOut, string bookingInfo, int nbPerson, string guestFirstName, string guestLastName, string email, string guestPhone, string guestInfo)
        {
            this.Userid = userid;
            this.RoomId = roomId;
            this.GuestId = guestId;
            this.BookingHasPayed = bookingHasPayed;
            this.BookingIsCreated = bookingIsCreated;
            this.CheckIn = checkIn;
            this.CheckOut = checkOut;
            this.BookingInfo = bookingInfo;
            this.NbPerson = nbPerson;
            this.GuestFirstName = guestFirstName;
            this.GuestLastName = guestLastName;
            this.Email = email;
            this.GuestPhone = guestPhone;
            this.GuestInfo = guestInfo;
        }
    }
}