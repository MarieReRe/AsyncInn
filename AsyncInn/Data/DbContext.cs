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

                });

            modelBuilder.Entity<Amenities>()
                .HasData(
                    new Amenities { Id = 1, Name = "Fridge" },
                    new Amenities { Id = 2, Name = "Coffee Pot" },
                    new Amenities { Id = 3, Name = "Hot Tub" }
                );

            modelBuilder.Entity<RoomAmenities>()
                .HasData(
                    new RoomAmenities { RoomId = 1, AmenitiesId = 1, },
                    new RoomAmenities { RoomId = 2, AmenitiesId = 1, },
                    new RoomAmenities { RoomId = 3, AmenitiesId = 1, },

                    new RoomAmenities { RoomId = 1, AmenitiesId = 2, },
                    new RoomAmenities { RoomId = 2, AmenitiesId = 2, },
                    new RoomAmenities { RoomId = 3, AmenitiesId = 2, },

                    new RoomAmenities { RoomId = 3, AmenitiesId = 3, }
                );

            modelBuilder.Entity<HotelRoom>()
                .HasData(
                    new HotelRoom { HotelId = 1, RoomId = 1, RoomNumber = 101, Rate = 100 },
                    new HotelRoom { HotelId = 1, RoomId = 2, RoomNumber = 202, Rate = 200 },
                    new HotelRoom { HotelId = 1, RoomId = 3, RoomNumber = 303, Rate = 500 }
                );
        }




        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
