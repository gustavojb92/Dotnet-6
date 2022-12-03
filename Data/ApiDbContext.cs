using Microsoft.EntityFrameworkCore;
using Dotnet_6.Models;

namespace Dotnet_6.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<DriverMedia> DriverMedias { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // one to many
            modelBuilder.Entity<Driver>()
                .HasOne(driver => driver.Team)
                    .WithMany(team => team.Drivers)
                    .HasForeignKey(driver => driver.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Driver_Team");

            //one to one
            modelBuilder.Entity<DriverMedia>()
            .HasOne(driverMedia => driverMedia.Driver)
                    .WithOne(driver => driver.DriverMedia)
                    .HasForeignKey<DriverMedia>(driverMedia => driverMedia.DriverId);
            ;
        }
    }
}