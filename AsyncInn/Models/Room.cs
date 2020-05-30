using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Style")]
        public Style Style { get; set; }

        [Required]
        [Display(Name = "Max Guests")]
        public int MaxGuests { get; set; }

        [Required]
        [Display(Name = "Bed Count")]
        public int BedCount { get; set; }

        [Required]
        [Display(Name = "Bed Style")]
        public BedStyle BedStyle { get; set; }




        //Navigation Properties
        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<RoomAmenities> Amenities { get; set; }
    }
    //Flags enum
    public enum Style
    {
        [Display(Name = "Pool View")]
        PoolView,
        [Display(Name = "Oceanfront View")]
        OceanFrontView,
        [Display(Name = "Coastal View")]
        CoastalView,
        [Display(Name = "Penthouse")]
        Penthouse,
        [Display(Name = "Corner Suite")]
        CornerSuite,
        [Display(Name = "Ground Floor")]
        GroundFloor
    }
    public enum BedStyle
    {
        [Display(Name = "King Size")]
        KingSize,
        [Display(Name = "Queen Size")]
        QueenSize,
        [Display(Name = "Twin Size")]
        Twin,

    }

   
}
