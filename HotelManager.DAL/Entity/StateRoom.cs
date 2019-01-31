using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Entity
{
    public class StateRoom : IEntity<int>
    {
        public int Id { get; set; }
        public string State_name { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Last_update { get; set; }
    }
}
