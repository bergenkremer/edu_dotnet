using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Implementation
{
    public class CityUpdateService : ICityUpdateService
    {
        private ICityDataAccess CityDataAccess { get; }

        public CityUpdateService(ICityDataAccess cityDataAccess)
        {
            CityDataAccess = cityDataAccess;
        }

        public Task<City> UpdateAsync(CityUpdateModel city)
        {
            return CityDataAccess.UpdateAsync(city);
        }
    }
}