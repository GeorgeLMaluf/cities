using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;

namespace api.Domain.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListAsync();
    }

}