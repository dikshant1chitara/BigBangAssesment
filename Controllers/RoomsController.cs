using BigBangAssesment.Models;
using BigBangAssesment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssesment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        private readonly RoomsInterface _RoomRepository;

        public RoomsController(RoomsInterface RoomsRepository)
        {
            _RoomRepository = RoomsRepository;
        }
        [HttpGet]
        public ActionResult<ICollection<Rooms>> GetAllHotels()
        {
            var hotels = _RoomRepository.GetAllRoom();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public ActionResult<ICollection<Rooms>> GetHotelById(int id)
        {
            var rooms = _RoomRepository.GetRoomById(id);
            return Ok(rooms);
        }

        [HttpPost]
        public ActionResult<ICollection<Rooms>> CreateHotel(Rooms rooms)
        {
            _RoomRepository.AddRoom(rooms);
            return Ok(rooms);
        }

        [HttpPut("{id}")]
        public ActionResult<ICollection<Rooms>> UpdateHotel(int id, Rooms rooms)
        {
            _RoomRepository.UpdateRoom(rooms, id);
            return Ok(rooms);
        }

        [HttpDelete("{id}")]
        public ActionResult<ICollection<Rooms>> DeleteHotel(int id)
        {
            _RoomRepository.DeleteRoom(id);
            return Ok(id);
        }
    }
}
