using BigBangAssesment.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssesment.Repository
{
    public class HotelRepository : HotelInterface
    {
        private readonly HotelRoomContext _dbContext;

        public HotelRepository(HotelRoomContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddHotel(Hotel hotel)
        {
            _dbContext.Hotels.Add(hotel);
            _dbContext.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            var hotel = _dbContext.Hotels.Find(id);
            _dbContext.Hotels.Remove(hotel);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _dbContext.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
           var userobj= _dbContext.Hotels.Find(id);
            return userobj;
        }

        public void UpdateHotel(Hotel hotel, int id)
        {
            var res = _dbContext.Hotels.Find(id);
            res.Location = hotel.Location;
            _dbContext.Hotels.Update(res);  
            _dbContext.SaveChanges();
        }

    }
}
