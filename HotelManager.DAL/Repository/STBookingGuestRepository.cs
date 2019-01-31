using HotelManager.DAL.Entity;
using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace HotelManager.DAL.Repository
{
    public class STBookingGuestRepository : BaseRepository<STBookingGuest, int>, ISTBookingGuestRepository
    {
        public STBookingGuestRepository(DBConnect db) : base(db) { }

        public override STBookingGuest Get(int id)
        {
            return GetAll().Where(x => x.Id == id).SingleOrDefault();
        }

        public override IEnumerable<STBookingGuest> GetAll()
        {
            Command cmd = new Command("EXECUTE GetAllBookingGuest");
            List<Dictionary<string, object>> results = DB.ExecuteReader(cmd);

            List<STBookingGuest> datas = new List<STBookingGuest>();

            foreach (Dictionary<string, object> data in results)
            {
                datas.Add(Convert(data));
            }

            return datas;
        }

        public override STBookingGuest Convert(Dictionary<string, object> Data)
        {
            return new STBookingGuest
            {
                Id = (int)Data["booking_id"],
                Userid = (int)Data["user_id"],
                RoomId = (int)Data["room_id"],
                GuestId = (int)Data["guest_id"],
                BookingHasPayed = (bool)Data["booking_has_payed"],
                BookingIsCreated = (bool)Data["booking_is_created"],
                CheckIn = (DateTime)Data["check_in"],
                CheckOut = (DateTime)Data["check_out"],
                BookingInfo = (string)Data["Booking_info"],
                NbPerson = (int)Data["nb_person"],
                GuestFirstName = (string)Data["guest_firstname"],
                GuestLastName = (string)Data["guest_lastname"],
                Email = (string)Data["guest_email"],
                GuestPhone = (string)Data["guest_phone"],
                GuestInfo = (string)Data["guest_info"]
            };
        }

        public override int Insert(STBookingGuest entity)
        {
            Command cmd = new Command($"EXECUTE InsertBookingGuest " +
                                                   $"@user_id, " +
                                                   $"@room_id, " +
                                                   $"@check_in, " +
                                                   $"@check_out, " +
                                                   $"@Booking_info," +
                                                   $"@nb_person," +
                                                   $"@guest_firstname," +
                                                   $"@guest_lastname," +
                                                   $"@guest_email," +
                                                   $"@guest_phone," +
                                                   $"@guest_info ");

            cmd.AddParameter("@user_id", entity.Userid);
            cmd.AddParameter("@room_id", entity.RoomId);
            cmd.AddParameter("@check_in", entity.CheckIn);
            cmd.AddParameter("@check_out", entity.CheckOut);
            cmd.AddParameter("@Booking_info", entity.BookingInfo);
            cmd.AddParameter("@nb_person", entity.NbPerson);
            cmd.AddParameter("@guest_firstname", entity.GuestFirstName);
            cmd.AddParameter("@guest_lastname", entity.GuestLastName);
            cmd.AddParameter("@guest_email", entity.Email);
            cmd.AddParameter("@guest_phone", entity.GuestPhone);
            cmd.AddParameter("@guest_info", entity.GuestInfo);

            List<Dictionary<string, object>> a = DB.ExecuteReader(cmd);
            
            if (a.Count != 0)
            {
                int  id;
                foreach (var item in a)
                {
                    foreach (KeyValuePair<string, object> b in item)
                    {
                        if((int)b.Value>0) return id = (int)b.Value;
                    }
                }

            }
                return 0;
        }

        public override bool Update(STBookingGuest entity)
        {
            Command cmd = new Command($"EXECUTE UpdateBookingGuest " +
                                                    $"@booking_id, " +
                                                    $"@user_id, " +
                                                    $"@room_id, " +
                                                    $"@guest_id," +
                                                    $"@booking_has_payed, " +
                                                    $"@booking_is_created, " +
                                                    $"@check_in, " +
                                                    $"@check_out, " +
                                                    $"@Booking_info," +
                                                    $"@nb_person," +
                                                    $"@guest_firstname," +
                                                    $"@guest_lastname," +
                                                    $"@guest_email," +
                                                    $"@guest_phone," +
                                                    $"@guest_info ");

            cmd.AddParameter("@booking_id", entity.Id);
            cmd.AddParameter("@user_id", entity.Userid);
            cmd.AddParameter("@room_id", entity.RoomId);
            cmd.AddParameter("@guest_id", entity.GuestId);
            cmd.AddParameter("@booking_has_payed", entity.BookingHasPayed == true ? 1 : 0);
            cmd.AddParameter("@booking_is_created", entity.BookingIsCreated == true ? 1 : 0);
            cmd.AddParameter("@check_in", entity.CheckIn);
            cmd.AddParameter("@check_out", entity.CheckOut);
            cmd.AddParameter("@Booking_info", String.IsNullOrEmpty(entity.BookingInfo) ? "" : entity.BookingInfo);
            cmd.AddParameter("@nb_person", entity.NbPerson);
            cmd.AddParameter("@guest_firstname", entity.GuestFirstName);
            cmd.AddParameter("@guest_lastname", entity.GuestLastName);
            cmd.AddParameter("@guest_email", entity.Email);
            cmd.AddParameter("@guest_phone", entity.GuestPhone);
            cmd.AddParameter("@guest_info", String.IsNullOrEmpty(entity.GuestInfo) ? "" : entity.GuestInfo);

            var truc = DB.ExecuteNonQuery(cmd);

            return truc > 0 ? true : false;
        }
    }
}
