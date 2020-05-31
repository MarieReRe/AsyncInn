using AsyncInn.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Web.Services
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetHotels();
        Task<Hotel> GetHotelById(long id);
        Task<Hotel> Create(Hotel hotel);
        Task<Hotel> Delete(long id);
        Task<Hotel> Edit(long id, Hotel hotel);
        
    }
}
