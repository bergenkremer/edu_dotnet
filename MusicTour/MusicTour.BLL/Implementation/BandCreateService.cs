using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.DataAccess.Contracts;
using MusicTour.DataAccess.Implementations;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Implementation
{
    public class BandCreateService : IBandCreateService
    {
        private IBandDataAccess BandDataAccess { get; }

        public BandCreateService(IBandDataAccess concertDataAccess)
        {
            BandDataAccess = concertDataAccess;
        }

        public Task<Band> CreateAsync(BandUpdateModel band)
        {
            return BandDataAccess.InsertAsync(band);
        }
    }
}