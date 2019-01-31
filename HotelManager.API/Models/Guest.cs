using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.API.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Add_info { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Last_update { get; set; }
        public bool IsActive { get; set; }

        public Guest()
        {
            Id = -1;
        }

        public Guest(string FirstName, string LastName, string Email, string Phone, string Add_info, DateTime Created_at, DateTime Last_update, bool IsActive)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Created_at = Created_at;
            this.Last_update = Last_update;
            this.IsActive = IsActive;
        }
    }
}