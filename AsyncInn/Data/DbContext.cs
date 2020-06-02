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
                    Id = 1,
                    HotelName = "Hotel Vulcano Porto",
                    StreetAddress = "Via Nazionale 3",
                    City = "Salina",
                    State = "Malfa",
                    Country = "Italy",
                },
                new Hotel
                {
                    Id = 2,
                    HotelName = "The Loren",
                    StreetAddress = "116 South Road",
                    City = "Tucker's Town",
                    State = "Hamilton Parish",
                    Country = "Bermuda",



                }) ; 

            modelBuilder.Entity<HotelRoom>()
                .HasKey(hotelRoom => new
                {
                    hotelRoom.HotelId,
                    hotelRoom.RoomNumber,
                });

            modelBuilder.Entity<Room>()
                .HasData(new Room
                {
                    Id = 1, 
                    Name = "Charming Room",
                    Style = Style.CoastalView,
                    MaxGuests = 2,
                    BedCount = 1,
                    BedStyle = BedStyle.QueenSize,  
                },
                new Room
                {
                    Id = 2,
                    Name = "Superior Room - Pool Floor",
                    Style = Style.PoolView,
                    MaxGuests = 2,
                    BedCount = 1,
                    BedStyle = BedStyle.KingSize,
                },
                new Room
                {
                    Id = 3,
                    Name = "Superior Room - Top Floor",
                    Style = Style.Penthouse,
                    MaxGuests = 2,
                    BedCount = 1,
                    BedStyle = BedStyle.KingSize,
                });


            modelBuilder.Entity<RoomAmenities>()
                .HasKey(roomAmenities => new
                {
                    roomAmenities.AmenitiesId,
                    roomAmenities.RoomId

                }) ;


            modelBuilder.Entity<Amenities>()
              .HasData(
                  new Amenities 
                  { 
                      Id = 1,
                      Name = "In-Room Spa Service"
                  },
                  new Amenities
                  { 
                      Id = 2,
                      Name = "Nespresso"
                  },
                  new Amenities
                  {
                      Id = 3,
                      Name = "Mini Bar"
                  },
                  new Amenities
                  { 
                      Id = 4, 
                      Name = "Large Screen TV" 
                  }
         );


        }  




        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set;}
    }
}
