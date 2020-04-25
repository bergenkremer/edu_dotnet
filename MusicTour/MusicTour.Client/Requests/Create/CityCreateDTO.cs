using System.ComponentModel.DataAnnotations;

namespace MusicTour.Client.Requests.Create
{
    public class CityCreateDTO
    {
        [Required(ErrorMessage = "City name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Timezone is required")]
        public int UTCTimezone { get; set; }
    }
}