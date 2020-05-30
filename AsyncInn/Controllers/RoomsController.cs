using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return Ok(await roomRepository.GetRooms());
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(long id)
        {
            RoomDTO room = await roomRepository.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(long id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            bool updatedRoom = await roomRepository.UpdateRoom(id, room);


            if (!updatedRoom)
            {
                return NotFound();
            }


            return NoContent();
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await roomRepository.SaveNewRoom(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(long id)
        {
            var room = await roomRepository.DeleteRoom(id);

            if (room == null)
            {
                return NotFound();
            }
            return room;
        }

        //AMENITIES GO HERE 

        // POST: api/Rooms/5/Amenities/17
        [HttpPost("{roomId}/Amenities/{amenityId}")]
        public async Task<ActionResult> AddRoomAmenity(long roomId, int amenityId)
        {
            await roomRepository.AddAmenityToRoom(amenityId, roomId);
            return NoContent();
        }

        // DELETE: api/Rooms/5/Amenities/17
        [HttpDelete("{roomId}/Amenities/{amenityId}")]
        public async Task<ActionResult> RemoveRoomAmenity(long roomId, int amenityId)
        {
            await roomRepository.RemoveAmenityFromRoom(amenityId, roomId);
            return NoContent();
        }
    }
}