using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Amenities>> GetAllRoomAmenities(int amenitiesID)
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenitiesById(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        
        public async Task<Amenities> SaveNewAmenity(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
            return amenities;
        }

        public Task<bool> UpdateAmenities(int id,Amenities amenities)
        {
            throw new NotImplementedException();
        }

       
    }
}
