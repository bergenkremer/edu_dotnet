using System.ComponentModel.DataAnnotations;

namespace MusicTour.Client.Requests.Create
{
    public class ConcertCreateDTO
    {
        
        
        [Required(ErrorMessage = "Time is required")]
        public string Time { get; set; }
        
        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }

        public int? CityId { get; set; }

        public int? BandId{ get; set; }
    }
}