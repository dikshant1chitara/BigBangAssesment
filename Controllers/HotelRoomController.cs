using BigBangAssesment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssesmentProject.Controllers
{
        // HotelRoomController
        [Route("api/hotelrooms")]
        [ApiController]
        public class HotelRoomController : ControllerBase
        {
            private readonly HotelRoomContext _context;

            public HotelRoomController(HotelRoomContext context)
            {
                _context = context;
            }

            // GET api/hotelrooms
            [HttpGet]
            public ActionResult<IEnumerable<HotelRoomDto>> GetHotelRooms()
            {
                var hotelRooms = _context.Hotels
                    .Join(
                        _context.Rooms,
                        hotel => hotel.HotelId,
                        room => room.HotelId,
                        (hotel, room) => new HotelRoomDto
                        {
                            HotelId = hotel.HotelId,
                            HotelName = hotel.Name,
                            RoomId = room.RoomId,
                            RoomType = room.RoomType,
                            RoomNumber = room.RoomNumber
                        }
                    )
                    .ToList();

                return Ok(hotelRooms);
            }
        }

        // HotelRoomDto
        public class HotelRoomDto
        {
            public int HotelId { get; set; }
            public string HotelName { get; set; }
            public int RoomId { get; set; }
            public string RoomType { get; set; }
            public string RoomNumber { get; set; }
        }

    
}
