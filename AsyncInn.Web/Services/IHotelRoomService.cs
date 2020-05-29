using AsyncInn.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Services
{
    public interface IHotelRoomService
    {
        Task<List<HotelRoomSummary>> GetHotelRooms();
        Task<HotelRoomSummary> GetHotelRoomById();
    }
}
