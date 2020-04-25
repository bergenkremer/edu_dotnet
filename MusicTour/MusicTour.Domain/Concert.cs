using MusicTour.Domain.Contracts;

namespace MusicTour.Domain
{
    public class Concert : ICityContainer, IBandContainer
    {
        public int Id { get; set; }
        
        public Band Band{ get; set; }

        public City City { get; set; }

        public string Date { get; set; }
        
        public string Time { get; set; }
        
        public int? CityId => City.Id;

        public int? BandId => Band.Id;
    }
}