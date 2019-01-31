using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set; }
        public int Id_profil { get; set; }
        public List<Profil> Profils { get; set; }
        public string HashPassword { get; set; }
        public string Email { get; set; }

        public User()
        {
            Id = -1;
        }

        public User(string FirstName, string LastName, DateTime Created_at, DateTime Last_update, bool IsActive, int Id_profil, string Email, string HashPassword)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CreatedAt = Created_at;
            this.LastUpdate = Last_update;
            this.IsActive = IsActive;
            this.Id_profil = Id_profil;
            this.Email = Email;
            this.HashPassword = HashPassword;
        }


    }
}