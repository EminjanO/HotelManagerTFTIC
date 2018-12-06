using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Entity
{
    public class Profil : IEntity<int>
    {
        public int Id { get; set; }
        public string Profil_Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
