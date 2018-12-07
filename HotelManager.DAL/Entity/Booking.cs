using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Entity
{
    public class Booking : IEntity<int>
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

    }
}
