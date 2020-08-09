using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;

namespace api.Domain.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();        
    }
}