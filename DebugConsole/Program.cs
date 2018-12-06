using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DAL.Repository;
using HotelManager.DAL.Entity;
using System.Reflection;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GuestRepository repo = new GuestRepository();
            //List<Guest> gs = (List<Guest>)repo.GetAll();

            //foreach (Guest g in gs)
            //{
            //    foreach (PropertyInfo item in g.GetType().GetProperties())
            //    {
            //        Console.WriteLine(item.GetValue(g));
            //    }
            //}

            //Guest g = new Guest {
            //    FirstName = "Marie",
            //    LastName = "Antoinette",
            //    Email = "M.A2@yolo.com",
            //    Phone = "056461865416",
            //    Add_info = null,
            //    Created_at = DateTime.Now,
            //    Last_update = DateTime.Now,
            //    IsActive = true
            //};

            Guest g1 = repo.Get(12);
            g1.FirstName = "YOLO";
            g1.Add_info = null;

            Console.WriteLine(repo.Delete(g1)); 


            Console.ReadLine();
        }
    }
}
