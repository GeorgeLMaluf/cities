using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;
using api.Domain.Services.Communication;

namespace api.Domain.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();
        Task<CityResponse> SaveAsSync(City city);

        Task<City> FindById(long id);

        Task<IEnumerable<City>>FindByPattern(string pattern);
        
        Task<CityResponse> UpdateAsync(long id, City city);

        Task<CityResponse> DeleteAsync(long id);
    }
}