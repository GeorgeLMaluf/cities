using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Domain.Models;
using api.Domain.Repositories;
using api.Persistence.Contexts;
using System.Linq;

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

        public async Task AddAsync(City city)
        {
            
            await _context.Cities.AddAsync(city);            
        }

        public async Task<City> FindByIdAsync(long id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<IEnumerable<City>> FindByPatternAsync(string pattern)
        {            
            var cities = await _context.Cities.ToListAsync();
            
            return cities.Where(c => (c.Cidade.Contains(pattern) || 
                c.Uf.Contains(pattern) ||
                c.Regiao.Contains(pattern))).Select(c => c).ToList();
        }
        public void Update(City city)
        {
            _context.Cities.Update(city);
        }

        public void Remove(City city)
        {
            _context.Cities.Remove(city);
        }        
    }
}