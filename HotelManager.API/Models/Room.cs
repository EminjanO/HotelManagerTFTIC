using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.API.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Num { get; set; }
        public string Add_info { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Last_update { get; set; }
        public bool IsActive { get; set; }
        public int Id_state_room { get; set; }
        public int Id_type_room { get; set; }
        public List<StateRoom> RoomStates { get; set; }
        public List<TypeRoom> RoomTypes { get; set; }

        public Room()
        {
            Id = -1;
        }

        public Room(string Num, string Add_info, DateTime Created_at, DateTime Last_update, bool IsActive, int Id_state_room, int Id_type_room)
        {
            this.Num = Num;
            this.Add_info = Add_info;
            this.Created_at = Created_at;
            this.Last_update = Last_update;
            this.IsActive = IsActive;
            this.Id_state_room = Id_state_room;
            this.Id_type_room = Id_type_room;
        }

    }
}