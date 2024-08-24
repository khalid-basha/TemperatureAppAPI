using Microsoft.EntityFrameworkCore;
using TemperatureApi.Models;


namespace TemperatureApi.Data
{
    public class TemperatureContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Device entity
            modelBuilder.Entity<Device>()
                .HasKey(d => d.DeviceId); // Primary key

            // Configure TemperatureReading entity
            modelBuilder.Entity<TemperatureReading>()
                .HasKey(th => th.ID); // Primary key

            modelBuilder.Entity<TemperatureReading>()
                .Property(th => th.TempValue)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            // Configure the relationship between TemperatureReading and Device
            modelBuilder.Entity<TemperatureReading>()
                .HasOne<Device>() // Specify the related entity type
                .WithMany() // No navigation property in Device
                .HasForeignKey(th => th.DeviceId) // Foreign key in TemperatureReading
                .OnDelete(DeleteBehavior.Cascade); // Optional: Specify delete behavior


            base.OnModelCreating(modelBuilder);
        }
        public TemperatureContext(DbContextOptions<TemperatureContext> options)
            : base(options)
        {
        }

        public DbSet<TemperatureReading> TempHistory { get; set; }
        
    }
}
