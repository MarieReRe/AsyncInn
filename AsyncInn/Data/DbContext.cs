using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {


        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel
                {
                    ID = 1,
                    HotelName = "Hotel Vulcano Porto",
                    StreetAddress = "Via Nazionale 3",
                    City = "Salina",
                    State = "Malfa",
                    Country = "Italy",
                });

            modelBuilder.Entity<HotelRoom>()
                .HasKey(hotelRoom => new
                {
                    hotelRoom.HotelId,
                    hotelRoom.RoomNumber,
                });

            modelBuilder.Entity<Room>()
                .HasData(new Room
                {
                    ID = 1, 
                    Name = "Charming Room",
                    Style = 1,
                    MaxGuests = 2,
                });
            modelBuilder.Entity<Room>()
              .HasData(new Room
              {
                  ID = 2,
                  Name = "Superior Room - Pool Floor",
                  Style = 1,
                  MaxGuests = 2,
              });
            modelBuilder.Entity<Room>()
            .HasData(new Room
            {
                ID = 3,
                Name = "Superior Room - Top Floor",
                Style = 1,
                MaxGuests = 2,
            });

        }  
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<Room> Room { get; set; }
    }
}
