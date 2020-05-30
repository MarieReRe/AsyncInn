using AsyncInn.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsyncInn.Web.Services
{
    public class HttpHotelService
    {

        private readonly HttpClient client;

        public HttpHotelService(HttpClient client)
        {
            this.client = client;
        }


        public async Task<List<HotelSummary>> GetHotels()
        {
            var responseStream = await client.GetStreamAsync("Hotels");
            List<HotelSummary> result = await JsonSerializer.DeserializeAsync<List<HotelSummary>>(responseStream);
            return result;
        }

        public async Task<HotelSummary> GetHotelById(long id)
        {
            var responseStream = await client.GetStreamAsync($"Hotels/{id}");
            HotelSummary result = await JsonSerializer.DeserializeAsync<HotelSummary>(responseStream);
            return result;
        }
    }
}
