using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Data.Interfaces;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        IAmenitiesRepository amenitiesRepository;

        public AmenitiesController(IAmenitiesRepository amenitiesRepository)
        {
            this.amenitiesRepository = amenitiesRepository;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenities>>> GetAmenities()
        {
            return Ok(await amenitiesRepository.GetAllRoomAmenities());
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenities>> GetAmenities(int id)
        {
            Amenities amenities = await amenitiesRepository.GetAmenitiesById(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
        }

        // PUT: api/Amenities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
        {
            amenities.Id = id;
            if (id != amenities.Id)
            {
                return BadRequest();
            }

            bool amenityUpdated = await amenitiesRepository.UpdateAmenities(id, amenities);

            if (!amenityUpdated)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Amenities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmenities", new { id = amenities.Id }, amenities);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
        {
            var amenities = await amenitiesRepository.DeleteAmenities(id);
            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
        }

        
    }
}
