using MusicTour.Client.Requests.Create;

namespace MusicTour.Client.Requests.Update
{
    public class ConcertUpdateDTO : ConcertCreateDTO
    {
        public int Id { get; set; }
    }
}