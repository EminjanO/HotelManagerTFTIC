using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class TypeRoom
    {

        public int Id { get; set; }
        public string Type_name { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public bool Kichen { get; set; }
        public bool Tub { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Last_update { get; set; }
        public bool IsActive { get; set; }

        public TypeRoom()
        {
            this.Id = -1;
        }
        public TypeRoom(string type_name, int capacity, decimal price, bool kichen, bool tub, DateTime created_at, DateTime last_update, bool isActive)
        {
           this.Id = Id;
           this.Type_name = type_name;
           this.Capacity = capacity;
           this.Price = price;
           this.Kichen = kichen;
           this.Tub = tub;
           this.Created_at = created_at;
           this.Last_update = last_update;
           this.IsActive = isActive;
        }
    }
}