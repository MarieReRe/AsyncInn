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
        }  
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
    }
}
