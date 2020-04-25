using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Implementation
{
    public class CityCreateService : ICityCreateService
    {
        private ICityDataAccess CityDataAccess { get; }

        public CityCreateService(ICityDataAccess cityDataAccess)
        {
            CityDataAccess = cityDataAccess;
        }

        public  Task<City> CreateAsync(CityUpdateModel city)
        {
            return CityDataAccess.InsertAsync(city);
        }
    }
}