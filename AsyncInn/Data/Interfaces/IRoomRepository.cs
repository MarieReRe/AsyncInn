using AsyncInn.Models;
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
        Task<Room> GetRoomById(long id);
        Task<List<Room>> GetRooms();

        //U: Update
        Task<bool> UpdateRoom(long id, Room room);

        //D: Delete
        Task<Room> DeleteRoom(long id);
    
    }
}
