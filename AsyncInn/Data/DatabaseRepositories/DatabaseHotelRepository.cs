using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.EntityFrameworkCore;
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



        public async Task<Hotel> CreateHotel( Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> DeleteHotel(long id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if(hotel == null)
            {
                return null;
            }
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;

        }
      
        public async Task<HotelDTO> GetHotelById(long id)
        {
            var hotel = await _context.Hotel
                .Select(hotel => new HotelDTO
                {
                    Id = hotel.Id,
                    Name = hotel.HotelName,
                    City = hotel.City,
                    State = hotel.State,
                    Country = hotel.Country,

                })
                .FirstOrDefaultAsync(hotel => hotel.Id == id);

            return hotel;

        }

        public async Task<IEnumerable<HotelDTO>> GetHotels()
        {
            var hotels = await _context.Hotel
                .Select(hotel => new HotelDTO
                {
                    Id = hotel.Id,
                    Name = hotel.HotelName,
                    City = hotel.City,
                    State = hotel.State,
                    Country = hotel.Country,

                    HotelRoom = hotel.HotelRoom
                    .Select(hotelRoom => new HotelRoomDTO
                    {
                        Name = hotelRoom.Hotel.HotelName,
                        HotelId = hotelRoom.HotelId,
                        Rate = hotelRoom.Rate,

                    })
                    .ToList()
                })
                .ToListAsync();
        }

        public async Task<Hotel> SaveNewHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<bool> UpdateHotel(long id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;

            }
            catch(DbUpdateConcurrencyException)
            {
                if(!HotelExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        

        private bool HotelExists(long id)
        {
            return _context.Hotel.Any(e => e.Id == id);
        }
    }
}
