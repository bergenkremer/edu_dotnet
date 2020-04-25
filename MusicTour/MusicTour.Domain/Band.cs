using MusicTour.Domain.Contracts;
using System.Collections.Generic;

namespace MusicTour.Domain
{
    public class Band 
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<string> Members { get; set; } = new List<string>();

        public string Genre { get; set; }
    }
}