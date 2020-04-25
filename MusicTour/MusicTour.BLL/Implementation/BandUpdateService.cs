using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Implementation
{
    public class BandUpdateService : IBandUpdateService
    {
        private IBandDataAccess BandDataAccess { get; }

        public BandUpdateService(IBandDataAccess concertDataAccess)
        {
            BandDataAccess = concertDataAccess;
        }

        public Task<Band> UpdateAsync(BandUpdateModel band)
        {
            return BandDataAccess.UpdateAsync(band);
        }
    }
}