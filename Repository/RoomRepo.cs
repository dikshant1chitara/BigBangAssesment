using BigBangAssesment.Models;

namespace BigBangAssesment.Repository
{
    public class RoomRepo : RoomsInterface
    {
        private readonly HotelRoomContext _dbContext;

        public RoomRepo(HotelRoomContext dbContext)
        {
            _dbContext = dbContext;
        }
        
            
        public Rooms GetRoomById(int id)
        {
            var userobj = _dbContext.Rooms.Find(id);
            return userobj;
        }

        public IEnumerable<Rooms> GetAllRoom()
        {
            return _dbContext.Rooms.ToList();
        }

        public void AddRoom(Rooms rooms)
        {
            _dbContext.Rooms.Add(rooms);
            _dbContext.SaveChanges();
        }

        public void UpdateRoom(Rooms rooms, int id)
        {
            var ress = _dbContext.Rooms.Find(id);
            ress.Availability = rooms.Availability;
            _dbContext.Rooms.Update(ress);
            _dbContext.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var Rooms = _dbContext.Rooms.Find(id);
            _dbContext.Rooms.Remove(Rooms);
            _dbContext.SaveChanges();
        }
    }   
        

     
}
