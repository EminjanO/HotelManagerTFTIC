using HotelManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace HotelManager.DAL.Repository
{
    public class UnitOfWork
    {
        public static UnitOfWork _instance = null;
        public static UnitOfWork Instance
        {
            get { return _instance = _instance ?? new UnitOfWork(); }
        }

        private DBConnect _db;

        #region BookingRepository
        private IBookingRepository _bookingRepository;

        public IBookingRepository BookingRepository
        {
            get { return _bookingRepository = _bookingRepository ?? new BookingRepository(_db); }
        }
        #endregion
        #region GuestRepository
        private IGuestRepository _guestRepository;
        
        public IGuestRepository GuestRepository
        {
            get { return _guestRepository = _guestRepository ?? new GuestRepository(_db); }
        }
        #endregion
        #region ProfilRepository
        private IProfilRepository _profilRepository;

        public IProfilRepository ProfilRepository
        {
            get { return _profilRepository = _profilRepository ?? new ProfilRepository(_db); }
        }
        #endregion
        #region RoomRepository
        private IRoomRepository _roomRepository;

        public IRoomRepository RoomRepository
        {
            get { return _roomRepository = _roomRepository ?? new RoomRepository(_db); }
        }
        #endregion
        #region StateRoomRepository
        private IStateRoomRepository _stateRoomRepository;

        public IStateRoomRepository StateRoomRepository
        {
            get { return _stateRoomRepository = _stateRoomRepository ?? new StateRoomRepository(_db); }
        }
        #endregion
        #region TypeRoomRepository
        private ITypeRoomRepository _typeRoomRepository;

        public ITypeRoomRepository TypeRoomRepository
        {
            get { return _typeRoomRepository = _typeRoomRepository ?? new TypeRoomRepository(_db); }
        }
        #endregion
        #region UserRepository
        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get { return _userRepository = _userRepository ?? new UserRepository(_db); }
        }
        #endregion
        private UnitOfWork()
        {
            _db = new DBConnect(@"Data Source = FORMA704\TFTIC; Initial Catalog = HotelManager; User ID = sa; Password = tftic@2012");
        }
    }
}
