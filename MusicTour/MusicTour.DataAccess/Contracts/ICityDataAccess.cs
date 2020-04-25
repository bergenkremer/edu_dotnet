using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;
using MusicTour.Domain.Models;
namespace MusicTour.DataAccess.Contracts
{
    public interface ICityDataAccess
    {
        Task<City> InsertAsync(CityUpdateModel city);
        Task<IEnumerable<City>> GetAsync();
        Task<City> GetAsync(ICityIdentity cityId);
        Task<City> UpdateAsync(CityUpdateModel city);
        Task<City> GetByAsync(ICityContainer departmentId);

    }
}