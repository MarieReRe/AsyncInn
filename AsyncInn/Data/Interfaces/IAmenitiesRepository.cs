using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Interfaces
{
   public interface IAmenitiesRepository
    {
        //C: Create
        Task<Amenities> CreateAmenities(Amenities amenities);

        //R: Read
        Task<Amenities> GetAmenitiesById(int id);

        //U: Update
        Task<Amenities> UpdateAmenities(int id, Amenities amenities);
        Task<Amenities> SaveNewAmenity(Amenities amenities);

        //D: Delete
        Task<Amenities> DeleteAmenities(int id);
        Task<IEnumerable<RoomAmenities>> GetAllRoomAmenities(int amenitiesID);

    }
}
