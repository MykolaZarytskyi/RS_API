using Microsoft.EntityFrameworkCore;
using RS_API.Data.Entities;

namespace RS_API.Data
{
    public class RSDbContext : DbContext
    {
        public RSDbContext(DbContextOptions<RSDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TruckCar>().HasData(new TruckCar[]
            {
                new TruckCar { Id=1, Mark= "MAN", Model= "TGX EVOLION", Capacity=15 },
                new TruckCar { Id = 2, Mark = "MAN", Model = "MAN XLION", Capacity = 18 },
                new TruckCar { Id = 3, Mark = "DAF", Model = "XF", Capacity = 12 },
                new TruckCar { Id = 4, Mark = "DAF", Model = "CF", Capacity = 14 }
            });


            modelBuilder.Entity<PassengerCar>().HasData(new PassengerCar[]
            {
                new PassengerCar { Id = 5, Mark = "BMW", Model = "M2", PassengersCount =5 },
                new PassengerCar { Id = 6, Mark = "BMW", Model = "X3M", PassengersCount = 5 },
                new PassengerCar { Id = 7, Mark = "BMW", Model = "Z4", PassengersCount = 2 },
                new PassengerCar { Id = 8, Mark = "VOLVO", Model = "S40", PassengersCount = 5 }
            });

            modelBuilder.Entity<Car>()
            .HasDiscriminator<string>("Car_type")
            .HasValue<TruckCar>("TruckCar")
            .HasValue<PassengerCar>("PassengerCar");

            base.OnModelCreating(modelBuilder);
        }
    }
}
