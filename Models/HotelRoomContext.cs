using Microsoft.EntityFrameworkCore;

namespace BigBangAssesment.Models
{
    public class HotelRoomContext:DbContext
    {
        public HotelRoomContext(DbContextOptions<HotelRoomContext> options) : base(options) { }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rooms>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);
        }
    }
}
