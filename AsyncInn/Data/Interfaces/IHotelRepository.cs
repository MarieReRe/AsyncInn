using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Interfaces
{
    public interface IHotelRepository
    {
   

        //C: Create
        Task<Hotel> CreateHotel(Hotel hotel);

        //R: Read
        Task<HotelDTO> GetHotelById(long id);
        Task<IEnumerable<HotelDTO>> GetHotels();

        //U: Update
        Task<bool> UpdateHotel(long id, Hotel hotel);
        Task<Hotel> SaveNewHotel(Hotel hotel);

        //D: Delete
        Task<Hotel> DeleteHotel(long id);
    }
}
