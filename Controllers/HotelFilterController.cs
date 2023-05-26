using BigBangAssesment.Models;
using BigBangAssesment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigBangAssesment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly HotelRoomContext dbContext;

        public HotelsController(HotelRoomContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET api/hotels
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetHotels(
            string? location, decimal? minPrice, decimal? maxPrice, string? amenities)
        {
            try
            {
                // Retrieve the values of the filtering criteria from the query parameters

                // Construct the base query to retrieve hotels
                IQueryable<Hotel> query = dbContext.Hotels;

                // Apply filters based on the provided criteria
                if (!string.IsNullOrEmpty(location))
                {
                    query = query.Where(h => h.Location == location);
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(h => h.Price >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(h => h.Price <= maxPrice.Value);
                }

                if (!string.IsNullOrEmpty(amenities))
                {
                    query = query.Where(h => h.Amenities.Contains(amenities));
                }

                // Execute the query and retrieve the filtered hotels
                List<Hotel> filteredHotels = query.ToList();

                // Return the filtered hotels as a response
                return Ok(filteredHotels);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an appropriate error response
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpGet("{hotelId}/available-rooms/count")]
        public ActionResult<int> GetAvailableRoomsCount(int hotelId)
        {
            try
            {
                // Retrieve the hotel by ID
                Hotel hotel = dbContext.Hotels.FirstOrDefault(h => h.HotelId == hotelId);

                if (hotel == null)
                {
                    return NotFound(); // Hotel not found
                }

                // Count the available rooms in the hotel
                int availableRoomsCount = dbContext.Rooms.Count(r => r.HotelId == hotelId && r.Availability == true);

                return Ok(availableRoomsCount);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an appropriate error response
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
