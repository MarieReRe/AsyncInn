using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncInn.Services
{
    public class HttpHotelRoomService : IHotelRoomService
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44334/api/"),
        };
        public Task<HotelRoom> GetHotelRoomById()
        {
            throw new NotImplementedException();
        }

        public Task<List<HotelRoom>> GetHotelRooms()
        {
            throw new NotImplementedException();
        }
    }
}
