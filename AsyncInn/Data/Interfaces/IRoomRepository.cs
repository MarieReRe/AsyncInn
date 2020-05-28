using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Interfaces
{
   public interface IRoomRepository
    {
        //C: Create
        Task<Room> CreateRoom(Room room);

        //R: Read
        Task<RoomDTO> GetRoomById(long id);
        Task<List<RoomDTO>> GetRooms();

        //U: Update
        Task<bool> UpdateRoom(long id, Room room);

        Task<RoomDTO> SaveNewRoom(Room room);

        //D: Delete
        Task<RoomDTO> DeleteRoom(long id);
    
    }
}
