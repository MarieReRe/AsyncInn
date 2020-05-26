using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.DatabaseRepositories
{
    public class DatabaseHotelRepository : IHotelRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseHotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

     

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public Task DeleteHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetHotelById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Hotel>> GetHotels()
        {
            throw new NotImplementedException();
        }

        public Task UpdateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
