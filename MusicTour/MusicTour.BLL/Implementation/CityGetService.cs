using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;

namespace MusicTour.BLL.Implementation
{
    
    public class CityGetService : ICityGetService
    {
        private ICityDataAccess CityDataAccess { get; }
        
        public CityGetService(ICityDataAccess cityDataAccess)
        {
            this.CityDataAccess = cityDataAccess;
        }
        public Task<IEnumerable<City>> GetAsync()
        {
            return this.CityDataAccess.GetAsync();
        }

        public Task<City> GetAsync(ICityIdentity city)
        {
            return this.CityDataAccess.GetAsync(city);
        }

        public async Task ValidateAsync(ICityContainer cityContainer)
        {
            if (cityContainer == null)
            {
                throw new ArgumentNullException(nameof(cityContainer));
            }
            
            var city = await this.GetBy(cityContainer);

            if (cityContainer.CityId.HasValue && city == null)
            {
                throw new InvalidOperationException($"City not found by id {cityContainer.CityId}");
            }
        }
        private Task<City> GetBy(ICityContainer cityContainer)
        {
            return this.CityDataAccess.GetByAsync(cityContainer);
        }
    }
}