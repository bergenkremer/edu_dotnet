using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Implementation
{
    public class ConcertCreateService : IConcertCreateService
    {
        private IConcertDataAccess ConcertDataAccess { get; }
        private IBandGetService BandGetService { get; }
        private ICityGetService CityGetService { get; }

        public ConcertCreateService(IConcertDataAccess concertDataAccess, ICityGetService cityGetService,
            IBandGetService bandGetService)
        {
            ConcertDataAccess = concertDataAccess;
            BandGetService = bandGetService;
            CityGetService = cityGetService;
        }

        public async Task<Concert> CreateAsync(ConcertUpdateModel concert)
        {
            await BandGetService.ValidateAsync(concert);
            await CityGetService.ValidateAsync(concert);

            return await ConcertDataAccess.InsertAsync(concert);

        }
    }
}