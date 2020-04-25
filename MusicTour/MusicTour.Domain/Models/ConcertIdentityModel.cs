using MusicTour.Domain.Contracts;

namespace MusicTour.Domain.Models
{
    public class ConcertIdentityModel : IConcertIdentity
    {
        public int Id { get; }

        public ConcertIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}