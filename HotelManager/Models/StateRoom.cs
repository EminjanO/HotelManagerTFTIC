using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class StateRoom
    {
        public int Id { get; set; }
        public string State_name { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Last_update { get; set; }
    }
}