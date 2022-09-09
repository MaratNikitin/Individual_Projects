using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WalksDbContext walksDbContext;

        public RegionRepository(WalksDbContext walksDbContext)
        {
            this.walksDbContext = walksDbContext;
        }
        
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await walksDbContext.Regions.ToListAsync();
        }
    }
}
