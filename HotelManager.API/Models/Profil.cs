using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.API.Models
{
    public class Profil
    {
        public Profil(string description, string profilName, bool isActive)
        {
            Description = description;
            ProfilName = profilName;
            IsActive = isActive;
        }

        public int Id { get; set; }
        public string ProfilName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}