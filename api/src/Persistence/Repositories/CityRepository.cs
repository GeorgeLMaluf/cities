using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Domain.Models;
using api.Domain.Repositories;
using api.Persistence.Contexts;

namespace api.Persistence.Repositories
{
    public class CityRepository: BaseRepository, ICityRepository
    {
        
        public CityRepository(AppDbContext context): base(context)
        {            
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}