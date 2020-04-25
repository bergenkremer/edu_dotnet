using MusicTour.Domain.Contracts;

namespace MusicTour.Domain.Models
{
    public class CityIdentityModel : ICityIdentity
    {
        public int Id { get; }

        public CityIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}