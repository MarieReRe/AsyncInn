using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Hotel> DeleteHotel(long id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
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

                    // TODO: HotelRoom = 
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
                    .Select(hr => new HotelRoomDTO
                    {
                        HotelId = hr.HotelId,
                        Rate = hr.Rate,
                        RoomNumber = hr.RoomNumber,
                        Room = new RoomDTO
                        {
                            Id = hr.Room.Id,
                            Name = hr.Room.Name,
                            Style = hr.Room.Style.ToString(),

                            Amenities = hr.Room.Amenities
                                .Select(ra => new AmenityDTO
                                {
                                    Id = ra.Amenities.Id,
                                    Name = ra.Amenities.Name,
                                })
                                .ToList(),
                        }
                    })
                    .ToList()
                })
                .ToListAsync();
            return hotels;
        }

        public async Task<HotelDTO> SaveNewHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return await GetHotelById(hotel.Id);
        }

        public async Task<bool> UpdateHotel(long id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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
