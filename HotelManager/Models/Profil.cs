using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class Profil
    {
        public int Id { get; set; }
        public string ProfilName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}