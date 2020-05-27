using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.DatabaseRepositories
{
    public class DatabaseAmenitiesRepository : IAmenitiesRepository
    {

        private readonly AsyncInnDbContext _context;

        public DatabaseAmenitiesRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Amenities> CreateAmenities(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
            return amenities;
        }

        public Task DeleteAmenities(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Amenities> GetAmenitiesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomAmenities>> GetRoomForRoomAmenities(int amenitiesID)
        {
            throw new NotImplementedException();
        }

        public Task<Amenities> SaveNewAmenity(Amenities amenities)
        {
            throw new NotImplementedException();
        }

        public Task<Amenities> UpdateAmenities(Amenities amenities)
        {
            throw new NotImplementedException();
        }
    }
}
