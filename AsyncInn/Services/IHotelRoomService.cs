using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Services
{
   public interface IHotelRoomService
    {
        Task<List<HotelRoom>> GetHotelRooms();
        Task<HotelRoom> GetHotelRoomById();
    }
}
