using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Entity
{
    public class Room : IEntity<int>
    {
        public int Id { get; set; }
        public string Num { get; set; }
        public string Add_info { get; set; }
        public int Id_type_room { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Last_update { get; set; }
        public int Id_state_room { get; set; }
    }
}
