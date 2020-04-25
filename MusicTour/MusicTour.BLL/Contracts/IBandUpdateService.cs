using System.Threading.Tasks;
using MusicTour.Domain;
using MusicTour.Domain.Models;

namespace MusicTour.BLL.Contracts
{
    public interface IBandUpdateService
    {
        Task<Band> UpdateAsync(BandUpdateModel band);
    }
}