using System.Collections.Generic;

namespace MusicTour.Client.DTO.Read
{
    public class BandDTO
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public ICollection<string> Members { get; set; } = new List<string>();

        public string Genre { get; set; }
       
    }
}