﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    partial class AsyncInnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            City = "Salina",
                            Country = "Italy",
                            HotelName = "Hotel Vulcano Porto",
                            State = "Malfa",
                            StreetAddress = "Via Nazionale 3"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<long>("HotelId")
                        .HasColumnType("bigint");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("HotelId", "RoomNumber");

                    b.HasIndex("RoomId");

                    b.ToTable("HotelRoom");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BedCount")
                        .HasColumnType("int");

                    b.Property<int>("BedStyle")
                        .HasColumnType("int");

                    b.Property<int>("MaxGuests")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Style")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            BedCount = 1,
                            BedStyle = 1,
                            MaxGuests = 2,
                            Name = "Charming Room",
                            Style = 2
                        },
                        new
                        {
                            ID = 2L,
                            BedCount = 1,
                            BedStyle = 0,
                            MaxGuests = 2,
                            Name = "Superior Room - Pool Floor",
                            Style = 0
                        },
                        new
                        {
                            ID = 3L,
                            BedCount = 1,
                            BedStyle = 0,
                            MaxGuests = 2,
                            Name = "Superior Room - Top Floor",
                            Style = 3
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesId")
                        .HasColumnType("int");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("AmenitiesId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenities")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
