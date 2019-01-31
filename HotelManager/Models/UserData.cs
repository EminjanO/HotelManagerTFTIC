using HotelManager.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Models
{
    public class UserData
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [HiddenInput]
        public int Id_profil { get; set; }

        public Profil Profil { get; set; }
        public List<Profil> Profils { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmez le Password")]
        public string ConfirmedPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [EmailUnique]
        [System.ComponentModel.DataAnnotations.Compare(nameof(Email))]
        [Display(Name = "Confirmez l'Email")]
        public string ConfirmedEmail { get; set; }

        public UserData()
        {
            this.Profils = new List<Profil>();
        }
    }
}