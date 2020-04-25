using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;

namespace MusicTour.BLL.Implementation
{
    public class BandGetService : IBandGetService
    {
        private IBandDataAccess BandDataAccess { get; }
        
        public BandGetService(IBandDataAccess bandDataAccess)
        {
            this.BandDataAccess = bandDataAccess;
        }
        public Task<IEnumerable<Band>> GetAsync()
        {
            return this.BandDataAccess.GetAsync();
        }

        public Task<Band> GetAsync(IBandIdentity band)
        {
            return this.BandDataAccess.GetAsync(band);
        }

        public async Task ValidateAsync(IBandContainer bandContainer)
        {
            if (bandContainer == null)
            {
                throw new ArgumentNullException(nameof(bandContainer));
            }
            
            var concert = await this.GetBy(bandContainer);

            if (bandContainer.BandId.HasValue && concert == null)
            {
                throw new InvalidOperationException($"Concert not found by id {bandContainer.BandId}");
            }
        }
        private Task<Band> GetBy(IBandContainer bandContainer)
        {
            return this.BandDataAccess.GetByAsync(bandContainer);
        }
    }
}