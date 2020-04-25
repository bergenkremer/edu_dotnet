using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Contracts
{
    public interface IConcertUpdateService
    {
        Task<Concert> UpdateAsync(ConcertUpdateModel concert);
    }
}