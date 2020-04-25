using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicTour.DataAccess.Entities
{
    public class Concert
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        
        public string Time { get; set; }
        
        public string Date { get; set; }
        
        public int? CityId { get; set; }

        public int? BandId { get; set; }

        public virtual Band Band { get; set; }

        public virtual City City { get; set; }
    }
}