using AsyncInn.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsyncInn.Web.Services
{
    public class HttpHotelService: IHotelService
    {

        private readonly HttpClient client;

        public HttpHotelService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<Hotel> Create(Hotel hotel)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(hotel), System.Text.Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync("Hotel", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    Hotel result = await JsonSerializer.DeserializeAsync<Hotel>(responseStream);
                    return result;
                }
                throw new Exception($"Failed to POST data: ({response.StatusCode})");
            }
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var responseStream = await client.GetStreamAsync("Hotels");
            List<Hotel> result = await JsonSerializer.DeserializeAsync<List<Hotel>>(responseStream);
            return result;
        }

        public async Task<Hotel> GetHotelById(long id)
        {
            var responseStream = await client.GetStreamAsync($"Hotels/{id}");
            Hotel result = await JsonSerializer.DeserializeAsync<Hotel>(responseStream);
            return result;
        }

       
    }
}
