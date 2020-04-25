using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;

namespace MusicTour.BLL.Contracts
{
    public interface IConcertGetService
    {
        Task<IEnumerable<Concert>> GetAsync();
        Task<Concert> GetAsync(IConcertIdentity concert);
        Task ValidateAsync(IConcertContainer concertContainer);
    }
}