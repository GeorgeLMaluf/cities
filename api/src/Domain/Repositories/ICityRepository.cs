using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;

namespace api.Domain.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListAsync();
        Task AddAsync(City city);

        Task<City> FindByIdAsync(long id);

        Task<IEnumerable<City>> FindByPatternAsync(string pattern);
        
        void Update(City city);

        void Remove(City city);
    }

}