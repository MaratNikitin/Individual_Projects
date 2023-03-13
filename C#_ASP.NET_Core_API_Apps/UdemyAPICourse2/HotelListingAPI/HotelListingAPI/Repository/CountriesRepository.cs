using HotelListingAPI.Contracts;
using HotelListingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        public HotelDbContext _context { get; }
        public CountriesRepository(HotelDbContext context) : base(context)
        {
            this._context = context;
        }


        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels)
                                    .FirstOrDefaultAsync(s => s.CountryId == id);
        }
    }
}
