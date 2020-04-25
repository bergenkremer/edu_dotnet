using MusicTour.Domain.Contracts;

namespace MusicTour.Domain.Models
{
    public class BandIdentityModel : IBandIdentity
    {
        public int Id { get; }

        public BandIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}