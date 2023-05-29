using BigBangAssesment.Models;
using System.ComponentModel.DataAnnotations;

namespace BigBangAssesmentProject.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        // Navigation property for the room
        public Rooms? Rooms { get; set; }
    }
}
