using HotelManager.API.Models;
using HotelManager.API.Util.ApiModel;
using HotelManager.API.Util.Mappers;
using HotelManager.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManager.API.Controllers
{
    public class BookingController : ApiController
    {
        [AcceptVerbs("GET")]
        public IndexBookingVM AllBooking()
        {
            List<BookingVM> bookingsVM = new List<BookingVM>();
            List<BookingVM> results = new List<BookingVM>();

            List<RoomTypeVM> roomtypeVM = new List<RoomTypeVM>();
         
            List<TypeRoom> TypeRooms = UnitOfWork.Instance.TypeRoomRepository.GetAll().Select(x => x.ToClient()).ToList();
            List<Room> Rooms = UnitOfWork.Instance.RoomRepository.GetAll().Select(x => x.ToClient()).ToList();
            var v = TypeRooms.GroupJoin(Rooms, t => t.Id, r => r.Id_type_room, (t, r) => new { TypeRoomId = t.Id, TypeRoomName = t.Type_name, Rooms = r });
            foreach (var item in v)
            {
                roomtypeVM.Add(
                    new RoomTypeVM
                    {
                        TypeRoomId = item.TypeRoomId,
                        TypeRoomName = item.TypeRoomName,
                        Rooms = item.Rooms.ToList(),
                    }); 
            }

                //GET ALL ACTIVE BOOKING FOR ONE YEAR 
                List<Booking> bookings = UnitOfWork.Instance.BookingRepository.GetAll().Select(x => x.ToClient()).ToList();


            foreach (Booking booking in bookings)
            {
                if(booking.IsActive)
                {
                    bookingsVM.Add(new BookingVM
                    {
                        _Booking = booking,
                        _Guest = UnitOfWork.Instance.GuestRepository.Get(booking.Id_guest).ToClient(),
                        _Room = UnitOfWork.Instance.RoomRepository.Get(booking.Id_room).ToClient(),
                        _RoomType = UnitOfWork.Instance.TypeRoomRepository.Get(UnitOfWork.Instance.RoomRepository.Get(booking.Id_room).ToClient().Id_type_room).ToClient(),
                        _RoomState = UnitOfWork.Instance.StateRoomRepository.Get(UnitOfWork.Instance.RoomRepository.Get(booking.Id_room).ToClient().Id_state_room).ToClient(),
                        _User = UnitOfWork.Instance.UserRepository.Get(booking.Id_user).ToClient(),
                    });
                }
            }
            //bookingsVM.Select(o => new { o.Booking.Id, o.Booking.Check_in, o.Booking.Check_out, o.Booking.Nb_night, o.Booking.Nb_person, o.Booking.Add_info, o.Booking.IsActive, o.Booking.IsCreated, o.Booking.HasPayed, o.Guest.Id  });
            foreach (BookingVM item in bookingsVM)
            {
                results.Add(new BookingVM
                {
                    BookingId = item._Booking.Id,
                    BookingCheckin = item._Booking.Check_in,
                    BookingCheckOut = item._Booking.Check_out,
                    BookingNBNight = item._Booking.Nb_night,
                    BookingNBPerson = item._Booking.Nb_person,
                    BookingAddInfo = item._Booking.Add_info,
                    BookingIsActive = item._Booking.IsActive,
                    BookingIsCreated = item._Booking.IsCreated,
                    BookingHasPayed = item._Booking.HasPayed,
                    GuestId = item._Guest.Id,
                    GuestFirstName = item._Guest.FirstName,
                    GuestLastName = item._Guest.LastName,
                    GuestInfo = item._Guest.Add_info,
                    GuestEmail = item._Guest.Email,
                    GuestPhone = item._Guest.Phone,
                    RoomId = item._Room.Id,
                    RoomType = item._RoomType.Type_name,
                    RoomNum = item._Room.Num,
                    UserId = item._User.Id,
                    UserName = item._User.LastName + " " + item._User.FirstName,
                    RoomstateId = item._RoomState.Id,
                    RoomStateName = item._RoomState.State_name,
                });
            }

            IndexBookingVM IndexBookingVMs = new IndexBookingVM {
                bookingVMs = results,
                roomtypeVMs = roomtypeVM,
            };

            return IndexBookingVMs;
        }

        [AcceptVerbs("GET")]
        public Booking Booking(int id)
        {
            return UnitOfWork.Instance.BookingRepository.Get(id).ToClient();
        }

        //[AcceptVerbs("POST")]
        public bool Delete(int id)
        {
            return UnitOfWork.Instance.BookingRepository.Delete(id);
            //return liste.Remove(e);
        }

        public int Post(STBookingGuest stb)
        {
            if (stb == null) return 0;
            stb.Userid = 1;
            return UnitOfWork.Instance.STBookingGuestRepository.Insert(stb.ToGlobal());
        }

        public bool Put(int id, STBookingGuest stb)
        {
            if (stb == null || id == 0) return false;

            return UnitOfWork.Instance.STBookingGuestRepository.Update(stb.ToGlobal());
        }
    }
}
