using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Implementation
{
    public class ConcertUpdateService : IConcertUpdateService
    {
        private IConcertDataAccess ConcertDataAccess { get; }
        private IBandGetService BandGetService { get; }
        private ICityGetService CityGetService { get; }

        public ConcertUpdateService(IConcertDataAccess concertDataAccess, ICityGetService cityGetService,
            IBandGetService bandGetService)
        {
            ConcertDataAccess = concertDataAccess;
            BandGetService = bandGetService;
            CityGetService = cityGetService;
        }

        public async Task<Concert> UpdateAsync(ConcertUpdateModel concert)
        {
            await BandGetService.ValidateAsync(concert);
            await CityGetService.ValidateAsync(concert);

            return await ConcertDataAccess.UpdateAsync(concert);

        }
    }
}