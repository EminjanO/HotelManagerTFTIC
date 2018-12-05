using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Entity
{
    public class TypeRoom : IEntity<int>
    {
        public int Id { get; set; }
        public string Type_name { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public bool Kichen { get; set; }
        public bool Tub { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Last_update { get; set; }
    }
}
