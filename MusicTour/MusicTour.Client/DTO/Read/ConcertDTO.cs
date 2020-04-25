namespace MusicTour.Client.DTO.Read
{
    public class ConcertDTO
    {
        public int Id { get; set; }

        public string Time { get; set; }
        
        public string Date { get; set; }

        public CityDTO City { get; set; }
        
        public BandDTO Band{ get; set; }
    }
}