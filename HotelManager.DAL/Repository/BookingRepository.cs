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
    public class BookingRepository : BaseRepository<Booking, int>, IBookingRepository
    {
        public BookingRepository(DBConnect db) : base(db) { }
        public override Booking Convert(Dictionary<string, object> Data)
        {
            return new Booking
            {
                Id = (int)Data["id"],
                Check_in = (DateTime)Data["check_in"],
                Check_out = (DateTime)Data["check_out"],
                Nb_night = (int)Data["nb_night"],
                Nb_person = (int)Data["nb_person"],
                Add_info = Data["add_info"]==DBNull.Value?null: (string)Data["add_info"],
                Created_at = (DateTime)Data["created_at"],
                Last_update = (DateTime)Data["last_update"],
                IsCreated = (bool)Data["isCreated"],
                IsActive = (bool)Data["isActive"],
                HasPayed = (bool)Data["hasPayed"],
                Id_guest = (int)Data["id_guest"],
                Id_room = (int)Data["id_room"],
                Id_user = (int)Data["id_user"]
            };
        }

        public override int Insert(Booking entity)
        {
            Command cmd = new Command($"EXECUTE InsertBooking @check_in, @check_out, @nb_person, @add_info, @id_guest, @id_room, @id_user");
            cmd.AddParameter("@check_in", entity.Check_in);
            cmd.AddParameter("@check_out", entity.Check_out);
            cmd.AddParameter("@nb_person", entity.Nb_person);
            cmd.AddParameter("@add_info", entity.Add_info);
            cmd.AddParameter("@id_guest", entity.Id_guest);
            cmd.AddParameter("@id_room", entity.Id_room);
            cmd.AddParameter("@id_user", entity.Id_user);

            return DB.ExecuteScalar<int>(cmd);
        }
        public override bool Update(Booking entity)
        {
            Command cmd = new Command($"UPDATE [booking] SET check_in = @check_in, check_out = @check_out, nb_person = @nb_person, add_info = @add_info, id_guest = @id_guest, id_room = @id_room, id_user = @id_user, last_update = {DateTime.Now} WHERE id = @id");
            cmd.AddParameter("@check_in", entity.Check_in);
            cmd.AddParameter("@check_out", entity.Check_out);
            cmd.AddParameter("@nb_person", entity.Nb_person);
            cmd.AddParameter("@add_info", entity.Add_info);
            cmd.AddParameter("@id_guest", entity.Id_guest);
            cmd.AddParameter("@id_room", entity.Id_room);
            cmd.AddParameter("@id_user", entity.Id_user);

            return DB.ExecuteNonQuery(cmd) == 0 ? false : true;
        }
    }
}
