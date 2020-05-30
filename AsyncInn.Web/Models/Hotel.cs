using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsyncInn.Web.Models
{
    public class Hotel
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }


        [JsonPropertyName("hotelName")]
        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }


        [JsonPropertyName("streetAddress")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }


        [JsonPropertyName("city")]
        [Display(Name = "City")]
        public string City { get; set; }


        [JsonPropertyName("state")]
        [Display(Name = "State")]
        public string State { get; set; }


        [JsonPropertyName("country")]
        [Display(Name = "Country")]
        public string Country { get; set; }


        public IEnumerable<HotelRoomSummary> HotelRoom { get; set; }
    }


}
