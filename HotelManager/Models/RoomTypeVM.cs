using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class RoomTypeVM
    {
        public int TypeRoomId { get; set; }
        public string TypeRoomName { get; set; }
        public List<Room> Rooms { get; set; }
        //public List<TypeRoom> TypeRooms { get; set; }
        //public List<Room> Rooms { get; set; }
        //public object data { get; set; }
    }
}