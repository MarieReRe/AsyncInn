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
        public int Style { get; set; }

        [Required]
        public int MaxGuests { get; set; }
    }
}
