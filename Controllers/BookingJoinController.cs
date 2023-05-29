using BigBangAssesment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssesmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingJoinController : ControllerBase
    {
        private readonly HotelRoomContext _context;

        public BookingJoinController(HotelRoomContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBookingWithRoom()
        {
            var bookingsWithRoom = _context.Booking
                .Include(b => b.Rooms) // Include the related Room entity
                .ToList();

            return Ok(bookingsWithRoom);
        }
    }
}
