using BigBangAssesment.Models;
using BigBangAssesment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;
using System.Security.AccessControl;

namespace BigBangAssesment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelInterface _hotelRepository;

        public HotelController(HotelInterface hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<Hotel>> GetAllHotels()
        {
            var hotels = _hotelRepository.GetAllHotels();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public ActionResult<ICollection<Hotel>> GetHotelById(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);
            return Ok(hotel);
        }

        [HttpPost]
        public ActionResult<ICollection<Hotel>> CreateHotel(Hotel hotel)
        {
            _hotelRepository.AddHotel(hotel);
            return Ok(hotel);
        }

        [HttpPut("{id}")]
        public ActionResult<ICollection<Hotel>> UpdateHotel(int id, Hotel hotel)
        {
            _hotelRepository.UpdateHotel(hotel, id);
            return Ok(hotel);
        }

        [HttpDelete("{id}")]
        public ActionResult<ICollection<Hotel>> DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
            return Ok(id);
        }

      
        

    }
}
