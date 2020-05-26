using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Interfaces
{
    interface IHotelRepository
    {

        //C: Create
        Task CreateHotel(Hotel hotel);

        //R: Read
        Task<Hotel> GetHotelById(long id);
        Task<List<Hotel>> GetHotels();

        //U: Update
        Task UpdateHotel(Hotel hotel);

        //D: Delete
        Task DeleteHotel(int id);
    }
}
