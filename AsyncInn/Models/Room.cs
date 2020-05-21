using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public long ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Style Style { get; set; }

        [Required]
        public int MaxGuests { get; set; }

        [Required]
        public int BedCount { get; set; }

        [Required]
        public BedStyle BedStyle { get; set; }
    }
    //Flags enum
    public enum Style
    {
        PoolView,
        OceanFrontView,
        CoastalView, 
        Penthouse, 
        CornerSuite, 
        GroundFloor
    }
    public enum BedStyle
    {
        KingSize,
        QueenSize,
        Twin,

    }
}
