using BigBangAssesment.Models;
using BigBangAssesmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssesmentProject.Controllers
{
    // BookingController
    [Authorize]
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly HotelRoomContext _context;

        public BookingController(HotelRoomContext context)
        {
            _context = context;
        }

        // POST api/bookings
        [HttpPost]
        public ActionResult<Bookings> CreateBooking(Bookings booking)
        {
            // Perform validation and booking logic
            // ...

            // Save the booking to the database
            _context.Booking.Add(booking);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }

        // GET api/bookings/{id}
        [HttpGet("{id}")]
        public ActionResult<Bookings> GetBooking(int id)
        {
            var booking = _context.Booking.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        // GET api/bookings/hotels/{hotelId}
        [HttpGet("hotels/{hotelId}")]
        public ActionResult<IEnumerable<Bookings>> GetBookingsByHotel(int hotelId)
        {
            var bookings = _context.Booking
                .Where(b => b.Rooms.HotelId == hotelId)
                .ToList();

            return Ok(bookings);
        }

        // GET api/bookings/customers/{customerId}
        [HttpGet("customers/{customerId}")]
        public ActionResult<IEnumerable<Bookings>> GetBookingsByCustomer(int customerId)
        {
            var bookings = _context.Booking
                .Where(b => b.CustomerId == customerId)
                .ToList();

            return Ok(bookings);
        }
    }



}
