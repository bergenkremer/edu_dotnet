using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicTour.DataAccess.Entities
{
        public partial class City
    {
        public City()
        {
            this.Concert = new HashSet<Concert>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Concert> Concert { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public int UTCTimezone { get; set; }
    }
}