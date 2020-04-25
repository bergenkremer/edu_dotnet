using MusicTour.Domain.Contracts;
using System.Collections.Generic;

namespace MusicTour.Domain.Models
{
    public class BandUpdateModel : IBandIdentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<string> Members { get; } = new List<string>();

        public string Genre { get; set; }
    }
}