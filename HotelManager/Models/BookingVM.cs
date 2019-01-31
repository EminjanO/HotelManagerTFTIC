using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Models
{
    public class BookingVM
    {
        [HiddenInput]
        //o.Booking.Id, o.Booking.Check_in, o.Booking.Check_out, o.Booking.Nb_night, o.Booking.Nb_person, o.Booking.Add_info, o.Booking.IsActive, o.Booking.IsCreated, o.Booking.HasPayed, o.Guest.Id 
        public int BookingId { get; set; }
        public DateTime BookingCheckin { get; set; }
        public DateTime BookingCheckOut { get; set; }
        public int BookingNBNight { get; set; }
        public int BookingNBPerson { get; set; }
        public string BookingAddInfo { get; set; }
        public bool BookingIsActive { get; set; }
        public bool BookingIsCreated { get; set; }
        public bool BookingHasPayed { get; set; }
        public int GuestId { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public string GuestInfo { get; set; }
        public string GuestEmail { get; set; }
        public string GuestPhone { get; set; }
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public string RoomNum { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoomstateId { get; set; }
        public string RoomStateName { get; set; }

        public List<Room> Rooms { get; set; }
        public Booking _Booking { get; set; }
        public Guest _Guest { get; set; }
        public Room _Room { get; set; }
        public TypeRoom _RoomType { get; set; }
        public StateRoom _RoomState { get; set; }
        public User _User { get; set; }

    }
}