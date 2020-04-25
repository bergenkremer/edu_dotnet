using MusicTour.Domain.Contracts;

namespace MusicTour.Domain.Models
{
    public class CityUpdateModel : ICityIdentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public int UTCTimezone { get; set; }
    }
}