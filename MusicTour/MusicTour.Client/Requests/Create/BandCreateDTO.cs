using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicTour.Client.Requests.Create
{
    public class BandCreateDTO
    {
        [Required(ErrorMessage = "Band name is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Member list is required")]
        public ICollection<string> Members { get; set;  } = new List<string>();

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
    }
}