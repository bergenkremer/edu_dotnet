using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;

namespace MusicTour.BLL.Contracts
{
    public interface ICityGetService
    {
        Task<IEnumerable<City>> GetAsync();
        Task<City> GetAsync(ICityIdentity city);
        Task ValidateAsync(ICityContainer cityContainer);
    }
}