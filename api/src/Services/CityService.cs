using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;
using api.Domain.Services;
using api.Domain.Repositories;

namespace api.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepo;

        public CityService(ICityRepository cityRepository) {
            this._cityRepo = cityRepository;
        }
        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _cityRepo.ListAsync();
        }
    }
}