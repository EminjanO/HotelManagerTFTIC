using System.Collections.Generic;
using HotelManager.DAL.Entity;

namespace HotelManager.DAL.Interface
{
    public interface IUserRepository : IRepository<User, int>
    {
        User Convert(Dictionary<string, object> Data);
        int Insert(User entity);
        bool Update(User entity);
        User CheckUser(string email, string password);
    }
}