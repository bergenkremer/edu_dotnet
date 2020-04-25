using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;

namespace MusicTour.BLL.Contracts
{
    public interface IBandGetService
    {
        Task<IEnumerable<Band>> GetAsync();
        Task<Band> GetAsync(IBandIdentity band);
        Task ValidateAsync(IBandContainer bandContainer);
    }
}