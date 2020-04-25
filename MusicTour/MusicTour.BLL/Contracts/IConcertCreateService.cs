using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Contracts
{
    public interface IConcertCreateService
    {
        Task<Concert> CreateAsync(ConcertUpdateModel concert);
    }
}