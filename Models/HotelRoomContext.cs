using BigBangAssesmentProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssesment.Models
{
   
        public class HotelRoomContext : DbContext
        {
            public HotelRoomContext(DbContextOptions<HotelRoomContext> options) : base(options) { }

            public DbSet<Hotel> Hotels { get; set; }
            public DbSet<Rooms> Rooms { get; set; }
            public DbSet<Bookings> Booking { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Rooms>()
                    .HasOne(r => r.Hotel)
                    .WithMany(h => h.Rooms)
                    .HasForeignKey(r => r.HotelId);

                modelBuilder.Entity<Bookings>()
                    .HasOne(b => b.Rooms)
                    .WithMany(r => r.Booking)
                    .HasForeignKey(b => b.RoomId);
            }
        }
       
}
