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
        Task CreateRoom(Room room);

        //R: Read
        Task<Room> GetRoomById(long id);
        Task<List<Room>> GetRooms();

        //U: Update
        Task UpdateRoom(Room room);

        //D: Delete
        Task DeleteRoom(long id);
    
    }
}
