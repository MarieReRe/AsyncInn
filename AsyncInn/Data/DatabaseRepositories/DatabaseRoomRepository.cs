using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.DatabaseRepositories
{
    public class DatabaseRoomRepository : IRoomRepository
    {

        private readonly AsyncInnDbContext _context;

        public DatabaseRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        } 

        public Task CreateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoom(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetRoomById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetRooms()
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
