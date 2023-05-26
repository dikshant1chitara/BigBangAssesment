using BigBangAssesment.Models;

namespace BigBangAssesment.Repository
{
    public interface HotelInterface
    {
        Hotel GetHotelById(int id);
        IEnumerable<Hotel> GetAllHotels();
        void AddHotel(Hotel hotel);
        void UpdateHotel(Hotel hotel, int id);
        void DeleteHotel(int id);


    }
}
