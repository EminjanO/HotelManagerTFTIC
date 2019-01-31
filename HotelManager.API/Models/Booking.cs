using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.API.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }
        public int Nb_night { get; set; }
        public int Nb_person { get; set; }
        public string Add_info { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Last_update { get; set; }
        public bool IsCreated { get; set; }
        public bool IsActive { get; set; }
        public bool HasPayed { get; set; }
        public int Id_guest { get; set; }
        public int Id_room { get; set; }
        public int Id_user { get; set; }

        public List<Guest> Guests { get; set; }
        public List<Room> Rooms { get; set; }
        public List<User> Users { get; set; }

        public Booking()
        {
            Id = -1;
        }

        public Booking(DateTime Check_in, DateTime Check_out, int Nb_night, int Nb_person, string Add_info, DateTime Created_at, DateTime Last_update, bool IsCreated, bool IsActive, bool HasPayed, int Id_guest, int Id_room, int Id_user)
        {
            this.Check_in = Check_in;
            this.Check_out = Check_out;
            this.Nb_night = Nb_night;
            this.Nb_person = Nb_person;
            this.Add_info = Add_info;
            this.Created_at = Created_at;
            this.Last_update = Last_update;
            this.IsCreated = IsCreated;
            this.IsActive = IsActive;
            this.HasPayed = HasPayed;
            this.Id_guest = Id_guest;
            this.Id_room = Id_room;
            this.Id_user = Id_user;
        }
    }
}