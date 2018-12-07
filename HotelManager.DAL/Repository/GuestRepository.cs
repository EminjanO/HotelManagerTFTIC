using HotelManager.DAL.Entity;
using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolDataBase;

namespace HotelManager.DAL.Repository
{
    //todo : Géré les null pour add_info pour Insert() et Update()

    public class GuestRepository : IRepository<Guest, int>
    {
        public Guest Get(int id)
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command("SELECT * FROM guest WHERE id = @id");
            cmd.AddParameter("@id", id);
            List<Dictionary<string, object>> guests = Connection.ExecuteReader(cmd);
            return new Guest {
                Id          = (int)     guests[0]["id"],
                FirstName   = (string)  guests[0]["firstname"],
                LastName    = (string)  guests[0]["lastname"],
                Email       = (string)  guests[0]["email"],
                Phone       = (string)  guests[0]["phone"],
                Add_info    =           guests[0]["add_info"] == DBNull.Value ? null : (string)guests[0]["add_info"],
                Created_at  = (DateTime)guests[0]["created_at"],
                Last_update = (DateTime)guests[0]["last_update"],
                IsActive    = (bool)    guests[0]["isActive"]
            };
        }

        public IEnumerable<Guest> GetAll()
        {
            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"SELECT * FROM guest");
            List<Dictionary<string, object>> guestsData = Connection.ExecuteReader(cmd);

            List<Guest> guests = new List<Guest>();

            foreach (Dictionary<string, object> guest in guestsData)
            {
                guests.Add(new Guest
                {
                    Id          = (int)     guest["id"],
                    FirstName   = (string)  guest["firstname"],
                    LastName    = (string)  guest["lastname"],
                    Email       = (string)  guest["email"],
                    Phone       = (string)  guest["phone"],
                    Add_info    =           guest["add_info"] == DBNull.Value ? null : (string)guest["add_info"],
                    Created_at  = (DateTime)guest["created_at"],
                    Last_update = (DateTime)guest["last_update"],
                    IsActive    = (bool)    guest["isActive"]
                });
            }

            return guests;
        }

        public int Insert(Guest entity)
        {
            string addinfo = entity.Add_info == null ? "NULL" : "'" + entity.Add_info + "'";

            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"EXECUTE InsertGuest @firstname, @lastname, @email, @phone, {addinfo}");

            cmd.AddParameter("@firstname"   , entity.FirstName);
            cmd.AddParameter("@lastname"    , entity.LastName);
            cmd.AddParameter("@email"       , entity.Email);
            cmd.AddParameter("@phone"       , entity.Phone);

            return Connection.ExecuteScalar<int>(cmd); 
        }

        public bool Update(Guest entity)
        {
            string addinfo = entity.Add_info == null ? "NULL" : "'" + entity.Add_info + "'";

            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command($"UPDATE guest SET firstname = @firstname, lastname = @lastname , email = @email, phone = @phone, add_info = '{addinfo}', last_update = '{DateTime.Now}' WHERE id = @id");

            cmd.AddParameter("@id",         entity.Id);
            cmd.AddParameter("@firstname",  entity.FirstName);
            cmd.AddParameter("@lastname",   entity.LastName);
            cmd.AddParameter("@email",      entity.Email);
            cmd.AddParameter("@phone",      entity.Phone);

            return Connection.ExecuteNonQuery(cmd) == 0 ? false : true;
        }

        public bool Delete(Guest entity)
        {
            string addinfo = entity.Add_info == null ? "NULL" : "'" + entity.Add_info + "'";

            DBConnect Connection = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
            Command cmd = new Command("DELETE guest WHERE id = @id");

            cmd.AddParameter("@id",         entity.Id);

            return Connection.ExecuteNonQuery(cmd) == 0 ? false : true;
        }
    }
}
