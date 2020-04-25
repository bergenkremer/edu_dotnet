using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;

namespace MusicTour.BLL.Implementation
{
    public class ConcertGetService : IConcertGetService
    {
        private IConcertDataAccess ConcertDataAccess { get; }
        
        public ConcertGetService(IConcertDataAccess cityDataAccess)
        {
            this.ConcertDataAccess = cityDataAccess;
        }
        public Task<IEnumerable<Concert>> GetAsync()
        {
            return this.ConcertDataAccess.GetAsync();
        }

        public Task<Concert> GetAsync(IConcertIdentity concert)
        {
            return this.ConcertDataAccess.GetAsync(concert);
        }

        public async Task ValidateAsync(IConcertContainer concertContainer)
        {
            if (concertContainer == null)
            {
                throw new ArgumentNullException(nameof(concertContainer));
            }
            
            var concert = await this.GetBy(concertContainer);

            if (concertContainer.ConcertId.HasValue && concert == null)
            {
                throw new InvalidOperationException($"Concert not found by id {concertContainer.ConcertId}");
            }
        }
        private Task<Concert> GetBy(IConcertContainer concertContainer)
        {
            return this.ConcertDataAccess.GetByAsync(concertContainer);
        }
    }
}