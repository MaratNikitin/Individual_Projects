using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data
{
    public class HotelDbContext: DbContext
    {
        public HotelDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Hotel> Hotels { get;set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    CountryId = 1,
                    CountryName= "Jamaica",
                    CountryShortName = "JM"
                },
                new Country
                {
                    CountryId = 2,
                    CountryName = "Bahamas",
                    CountryShortName = "BS"
                },
                new Country
                {
                    CountryId = 3,
                    CountryName = "Cayman Islands",
                    CountryShortName = "CI"
                }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    HotelId = 1,
                    HotelName = "Sandals Resort & Spa",
                    Address = "Negril",
                    CountryId = 1,
                    Rating= 4.5
                },
                new Hotel
                {
                    HotelId = 2,
                    HotelName = "Confort Suites",
                    Address = "George Town",
                    CountryId = 3,
                    Rating = 4.3
                },
                new Hotel
                {
                    HotelId = 3,
                    HotelName = "Grand Palladium",
                    Address = "Nassua",
                    CountryId = 2,
                    Rating = 4.1
                }
            );
        }
    }
}
