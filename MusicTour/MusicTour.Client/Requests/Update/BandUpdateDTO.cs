using MusicTour.Client.Requests.Create;

namespace MusicTour.Client.Requests.Update
{
    public class BandUpdateDTO : BandCreateDTO
    {
        public int Id { get; set; }
    }
}