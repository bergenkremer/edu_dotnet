using MusicTour.Domain.Contracts;

namespace MusicTour.Domain.Models
{
    public class ConcertUpdateModel : IConcertIdentity, IBandContainer, ICityContainer
    {
        public int Id { get; set; }
        
        public string Time { get; set; }
        
        public string Date { get; set; }
        
        public int? BandId { get; set; }
        public int? CityId { get; set; }
    }
}