using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Data.Interfaces
{
    public interface IAmenitiesRepository
    {
        //C: Create
        Task<Amenities> CreateAmenities(Amenities amenities);

        //R: Read
        Task<AmenityDTO> GetAmenitiesById(int Id);

        //U: Update
        Task<bool> UpdateAmenities(int Id, Amenities amenities);
        Task<AmenityDTO> SaveNewAmenity(Amenities amenities);

        //D: Delete
        Task<Amenities> DeleteAmenities(int Id);
        Task<IEnumerable<AmenityDTO>> GetAllRoomAmenities();

    }
}
