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

        public async Task<Amenities> DeleteAmenities(int id)
        {
            var deletedAmenity = await _context.Amenities.FindAsync(id);
            if(deletedAmenity == null)
            {
                return null;
            }
            _context.Amenities.Remove(deletedAmenity);
            await _context.SaveChangesAsync();

            return deletedAmenity;


        }

        public Task<Amenities> GetAmenitiesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomAmenities>> GetAllRoomAmenities(int amenitiesID)
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
