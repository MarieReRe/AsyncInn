using AsyncInn.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsyncInn.Services
{
    public class HttpHotelRoomService : IHotelRoomService
    {
        private readonly HttpClient client;

        public HttpHotelRoomService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<HotelRoomSummary> CreateHotelRoom(HotelRoomSummary hotelRoom)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(hotelRoom), System.Text.Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync("Hotel", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    HotelRoomSummary result = await JsonSerializer.DeserializeAsync<HotelRoomSummary>(responseStream);
                    return result;
                }
                throw new Exception($"Failed to POST data: ({response.StatusCode})");
            }
        }
        public async Task<HotelRoomSummary> GetHotelRoomById(long id)
        {
            var responseStream = await client.GetStreamAsync($"HotelRooms/{id}");
            HotelRoomSummary result = await JsonSerializer.DeserializeAsync<HotelRoomSummary>(responseStream);
            return result;
        }

        public async Task<List<HotelRoomSummary>> GetHotelRooms()
        {
            var responseStream = await client.GetStreamAsync("HotelRooms");
            List<HotelRoomSummary> result = await JsonSerializer.DeserializeAsync<List<HotelRoomSummary>>(responseStream);
            return result;
        }
    }
}
