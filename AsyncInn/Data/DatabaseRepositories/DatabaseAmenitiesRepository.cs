﻿using AsyncInn.Data.Interfaces;
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

        public async Task<Amenities> DeleteAmenities(int amenitiesId)
        {
            var deletedAmenity = await _context.Amenities.FindAsync(amenitiesId);
            if(deletedAmenity == null)
            {
                return null;
            }
            _context.Amenities.Remove(deletedAmenity);
            await _context.SaveChangesAsync();

            return deletedAmenity;


        }
      
        public async Task<Amenities> GetAmenitiesById(int amenitiesId)
        {
            return await _context.Amenities.FindAsync(amenitiesId);
        }

        
        public async Task<Amenities> SaveNewAmenity(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task<bool> UpdateAmenities(int amenitiesId, Amenities amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(amenitiesId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        public bool AmenityExists(int amenitiesId)
        {
            return _context.Amenities.Any(e => e.Id == amenitiesId);
        }

        public async Task<IEnumerable<Amenities>> GetAllRoomAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }
    }
}
