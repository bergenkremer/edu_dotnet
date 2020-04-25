using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;
using MusicTour.Domain.Models;
namespace MusicTour.DataAccess.Contracts
{
    public interface IConcertDataAccess
    {
        Task<Concert> InsertAsync(ConcertUpdateModel concert);
        Task<IEnumerable<Concert>> GetAsync();
        Task<Concert> GetAsync(IConcertIdentity concertId);
        Task<Concert> UpdateAsync(ConcertUpdateModel concert);
        Task<Concert> GetByAsync(IConcertContainer concert);

    }
}