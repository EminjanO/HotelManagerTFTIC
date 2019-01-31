using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class RoomTypeRoomVM
    {
        public int TypeRoomId { get; set; }
        public string Type_name { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public bool Kichen { get; set; }
        public bool Tub { get; set; }
        public int RoomId { get; set; }
        public string Num { get; set; }
        public string Add_info { get; set; }
        public List<string> BlobLinkPhoto { get; set; }
        public RoomTypeRoomVM()
        {
            BlobLinkPhoto = new List<string>();
        }
    }
}