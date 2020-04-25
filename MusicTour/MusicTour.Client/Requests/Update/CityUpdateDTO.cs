using MusicTour.Client.Requests.Create;

namespace MusicTour.Client.Requests.Update
{
    public class CityUpdateDTO : CityCreateDTO
    {
        public int Id { get; set; }
    }
}