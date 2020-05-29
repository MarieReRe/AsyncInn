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
using AsyncInn.Models.DTOs;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        IHotelRepository hotelRepository;

        public HotelsController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }


        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            return Ok(await hotelRepository.GetHotels());
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(long id)
        {
            var hotel = await hotelRepository.GetHotelById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(long id, Hotel hotel)
        {
            hotel.Id = id;
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await hotelRepository.UpdateHotel(id, hotel);


            if (!didUpdate)
            {
                return NotFound();
            }



            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await hotelRepository.SaveNewHotel(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(long id)
        {
            var hotel = await hotelRepository.DeleteHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }


    }
}
