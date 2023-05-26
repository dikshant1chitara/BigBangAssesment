using BigBangAssesment.Models;

namespace BigBangAssesment.Repository
{
    public interface RoomsInterface
    {
        Rooms GetRoomById(int id);
        IEnumerable<Rooms> GetAllRoom();
        void AddRoom(Rooms rooms);
        void UpdateRoom(Rooms rooms, int id);
        void DeleteRoom(int id);
    }
}
