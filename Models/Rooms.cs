using System.ComponentModel.DataAnnotations;

namespace BigBangAssesment.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        public int? HotelId { get; set; }
        public string? RoomType { get; set; }
        public bool? Availability { get; set; }

        public string? RoomNumber { get; set; }

        // Navigation property for the hotel
        public Hotel? Hotel { get; set; }
    }
}
