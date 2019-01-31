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
    public class RoomController : ApiController
    {
        [AcceptVerbs("GET")]
        public RoomTypeRoomVM Room(int id)
        {
            Room room = UnitOfWork.Instance.RoomRepository.Get(id).ToClient();
            TypeRoom typeroom = UnitOfWork.Instance.TypeRoomRepository.Get(room.Id_type_room).ToClient();

            return new RoomTypeRoomVM
            {
                RoomId = room.Id,
                Price = typeroom.Price,
                Add_info = room.Add_info,
                Capacity = typeroom.Capacity,
                Kichen = typeroom.Kichen,
                Tub = typeroom.Tub,
                Num = room.Num,
                Type_name = typeroom.Type_name,
                TypeRoomId = typeroom.Id,
            }; 
        }
    }
}
