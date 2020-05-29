using AsyncInn.Web.Models;
using System;
using System.Collections.Generic;
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
        public Task<HotelRoomSummary> GetHotelRoomById()
        {
            throw new NotImplementedException();
        }

        public Task<List<HotelRoomSummary>> GetHotelRooms()
        {
            throw new NotImplementedException();
        }
    }
}
