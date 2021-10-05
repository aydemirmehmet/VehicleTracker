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
                entity.Property(x => x.Id).UseIdentityColumn();
            
            });


            modelBuilder.Entity<Vehicle>(entity => {
                entity.Property(x => x.Id).UseIdentityColumn();
              
            });
          

            modelBuilder.Entity<VehiclePosition>(entity => {
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(x => x.Vehicle).WithMany(x => x.VehiclePositions).HasForeignKey(x => x.VehicleId).HasConstraintName("VehiclePositions_Place_FK");

            });

            modelBuilder.Entity<Report>(entity => {
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(x => x.Vehicle).WithMany(x => x.Reports).HasForeignKey(x => x.VehicleId).HasConstraintName("Report_Vehicle_FK");
                entity.HasOne(x => x.Place).WithMany(x => x.Reports).HasForeignKey(x => x.PlaceId).HasConstraintName("Report_Place_FK");

            });


        }

    }
}