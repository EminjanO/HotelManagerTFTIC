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

            //Guest ginsert = new Guest
            //{
            //    FirstName = "Marie",
            //    LastName = "Antoinette",
            //    Email = "M.A2@yolo.com",
            //    Phone = "056461865416",
            //    Add_info = null,
            //    Created_at = DateTime.Now,
            //    Last_update = DateTime.Now,
            //    IsActive = true
            //};
            //int gint = UnitOfWork.Instance.GuestRepository.Insert(ginsert);
            //Console.WriteLine(gint);

            //Guest g = UnitOfWork.Instance.GuestRepository.Get(1);
            User g = UnitOfWork.Instance.UserRepository.Get(1);

            List<User> gs = UnitOfWork.Instance.UserRepository.GetAll().ToList();


            foreach (User guest in gs)
            {
                Console.WriteLine("----");
                foreach (PropertyInfo item in guest.GetType().GetProperties())
                {
                    Console.WriteLine(item.GetValue(guest));
                }
            }
            Console.ReadLine();
        }
    }
}
