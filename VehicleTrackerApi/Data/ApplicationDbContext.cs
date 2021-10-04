using Microsoft.EntityFrameworkCore;
using VehicleTrackerApi;
using VehicleTrackerApi.Data.Model;

namespace VehicleApi.Contexts
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePosition> VehiclePositions { get; set; }
        public DbSet<Report> Reports { get; set; }

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            modelBuilder.Entity<Place>(entity=> {
                entity.Property(x => x.Id)
                       .UseIdentityColumn();
                entity.HasMany(x => x.Reports).WithOne(x => x.Place).HasForeignKey(x => x.PlaceId);
            });


            modelBuilder.Entity<Vehicle>(entity => {
                entity.Property(x => x.Id)
                       .UseIdentityColumn();
                entity.HasMany(x => x.Reports).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId);
            });
          

            modelBuilder.Entity<VehiclePosition>(entity => {
                entity.Property(x => x.Id).UseIdentityColumn();

            });

            modelBuilder.Entity<Report>(entity => {
                entity.Property(x => x.Id).UseIdentityColumn();

            });


        }

    }
}