using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicTour.DataAccess.Entities
{
    public class Band
    {
        public Band()
        {
            this.Concert = new HashSet<Concert>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<string> Members { get; } = new List<string>();

        public string Genre { get; set; }

        public virtual ICollection<Concert> Concert { get; set; }
    }
}