using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.DAL.Repository;
using HotelManager.DAL.Entity;
using System.Reflection;
using HotelManager.Help;
using Microsoft.WindowsAzure.Storage.Blob;

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


            //List<User> gs = UnitOfWork.Instance.UserRepository.GetAll().ToList();

            //foreach (User guest in gs)
            //{
            //    Console.WriteLine("----");
            //    foreach (PropertyInfo item in guest.GetType().GetProperties())
            //    {
            //        Console.WriteLine(item.GetValue(guest));
            //    }
            //}




            //STBookingGuest bookGuest = new STBookingGuest
            //{
            //    Id = 1,
            //    Userid = 1,
            //    RoomId = 1,
            //    GuestId = 1,
            //    BookingHasPayed = true,
            //    BookingIsCreated = true,
            //    CheckIn = DateTime.Now,
            //    CheckOut = DateTime.Now,
            //    BookingInfo = "Bonjour",
            //    NbPerson = 3,
            //    GuestFirstName = "Eminjan",
            //    GuestLastName = "Obama",
            //    Email = "Barack.obama@us.us",
            //    GuestPhone = "86741654",
            //    GuestInfo = "USA President"
            //};

            //int result = UnitOfWork.Instance.STBookingGuestRepository.Insert(bookGuest);

            //Console.WriteLine(result);

            //Console.WriteLine(UnitOfWork.Instance.UserRepository.CheckUser("wil.wil@email.com", "test1234="));

            //Task<List<IListBlobItem>> v = BlobStockage.GetBlobPhoto("hotelmanagerphoto");
            //foreach(var i in v.Result)
            //{
            //    Console.WriteLine(i.Uri);
            //}
            //Console.WriteLine(BlobStockage.GetBlobPhoto("hotelmanagerphoto"));
            Console.ReadLine();
        }
    }
}
