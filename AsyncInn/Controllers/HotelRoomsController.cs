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
            return Ok(await hotelRoomRepository.GetHotelRooms());
        }

        // GET: api/HotelRooms/5 <---- in post method for routing
        [HttpGet("{RoomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int roomNumber, long hotelId)
        {
            //change this to rely on hotel room repository
            var hotelRoom = await hotelRoomRepository.GetHotelRoomById(roomNumber, hotelId);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5

        [HttpPut("{RoomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int roomNumber, CreateHotelRoom hotelRoomData)
        {
            if (roomNumber != hotelRoomData.RoomNumber)
            {
                return BadRequest();
            }

            bool updateComplete = await hotelRoomRepository.UpdateHotelRooms(roomNumber, hotelRoomData);

            if (!updateComplete)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/HotelRooms
      
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(CreateHotelRoom hotelRoomData)
        {
            var hotelRoom = await hotelRoomRepository.SaveNewHotelRoom(hotelRoomData);

            // params to get the routes <---remind for tomorrow
            return CreatedAtAction("GetHotelRoom", new { hotelRoom.HotelId, hotelRoom.RoomNumber }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{RoomNumber}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int roomNumber, long hotelId)
        {
            var hotelRoom = await hotelRoomRepository.RemoveHotelRoom(roomNumber, hotelId);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

    }
}
