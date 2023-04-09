using Microsoft.EntityFrameworkCore;
using WebApplication5.Entity;
using WebApplication5.ViewModel;

namespace WebApplication5.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly MyDbContext _context;

        public LocationRepository(MyDbContext context) {
            _context = context;
        }
        public async Task<List<Location>> getAllLocationAsyn()
        {
            var Location = await (from l in _context.DIADIEMs.AsNoTracking()
                            select new Location()
                            {
                                TENDIADIEM = l.TENDIADIEM,
                                DIACHI = l.DIACHI,
                                Images = (from i in _context.image_DIADIEMs.AsNoTracking()
                                          where i.id_DIADIEM == l.ID select i.Name).ToList(),
                            }).ToListAsync();
            return Location;
        }
    }
}
