using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.API.Models
{
    public class StateRoom
    {
        public int Id { get; set; }
        public string State_name { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Last_update { get; set; }
        public StateRoom()
        {
            this.Id = -1;
        }

        public StateRoom(string state_name, DateTime created_at, DateTime last_update)
        {
           this.State_name = state_name;
           this.Created_at = created_at;
           this.Last_update = last_update;
        }
    }
}