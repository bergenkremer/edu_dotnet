using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;
using MusicTour.Domain.Models;

namespace MusicTour.DataAccess.Contracts
{
    public interface IBandDataAccess
    {
        Task<Band> InsertAsync(BandUpdateModel band);
        Task<IEnumerable<Band>> GetAsync();
        Task<Band> GetAsync(IBandIdentity bandId);
        Task<Band> UpdateAsync(BandUpdateModel band);
        Task<Band> GetByAsync(IBandContainer band);

    }
}