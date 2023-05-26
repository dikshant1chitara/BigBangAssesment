using System.ComponentModel.DataAnnotations;

namespace BigBangAssesment.Models
{
    public class Hotel
    {

        [Key]
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public decimal? Price { get; set; }
        public string? Amenities { get; set; }

        // Navigation property for the rooms
        public ICollection<Rooms>? Rooms { get; set; }
    }
}
