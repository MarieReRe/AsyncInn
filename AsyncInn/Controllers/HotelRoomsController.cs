using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.ApiRecievals;
using AsyncInn.Data.Interfaces;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Controllers
{
    [Route("api/Hotels/{HotelId}/Rooms")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        IHotelRoomRepository hotelRoomRepository;
       public HotelRoomsController(IHotelRoomRepository hotelRoomRepository)
        {
            this.hotelRoomRepository = hotelRoomRepository;
        }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms()
        {
            return Ok (await hotelRoomRepository.GetHotelRooms());
        }

        // GET: api/HotelRooms/5 <---- in post method for routing
        [HttpGet("{RoomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int roomNumber, long hotelId)
        {
            //change this to rely on hotel room repository
            var hotelRoom = await hotelRoomRepository.GetHotelRoomById(hotelId);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
  
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(long id, CreateHotelRoom hotelRoomData)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

           bool updateComplete = await hotelRoomRepository.UpdateHotelRooms(id, room);

                if (!HotelRoomExists(id))
                {
                    return NotFound();
                }
                
            return NoContent();
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(CreateHotelRoom hotelRoomData)
        {
            var hotelRoom = await hotelRoomRepository.SaveNewHotelRoom(hotelRoomData);
           
            // params to get the routes <---remind for tomorrow
            return CreatedAtAction("GetHotelRoom", new { hotelRoom.HotelId, hotelRoom.RoomNumber}, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(long id)
        {
            var hotelRoom = await _context.HotelRoom.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        private bool HotelRoomExists(long id)
        {
            return _context.HotelRoom.Any(e => e.HotelId == id);
        }
    }
}
