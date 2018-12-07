using System.Collections.Generic;
using HotelManager.DAL.Entity;

namespace HotelManager.DAL.Interface
{
    public interface IProfilRepository : IRepository<Profil, int>
    {
        Profil Convert(Dictionary<string, object> Data);
        int Insert(Profil entity);
        bool Update(Profil entity);
    }
}