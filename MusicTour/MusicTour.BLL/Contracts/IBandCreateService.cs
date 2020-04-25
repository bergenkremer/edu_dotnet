using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Contracts
{
    public interface IBandCreateService
    {
        Task<Band> CreateAsync(BandUpdateModel band);
    }
}