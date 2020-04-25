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

        //Название группы
        public string Name { get; set; }

        //Состав
        public ICollection<string> Members { get; } = new List<string>();

        //Жанр
        public string Genre { get; set; }

        public virtual ICollection<Concert> Concert { get; set; }
    }
}