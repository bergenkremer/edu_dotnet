using MusicTour.Domain.Contracts;
using System.Collections.Generic;

namespace MusicTour.Domain.Models
{
    public class BandUpdateModel : IBandIdentity
    {
        public int Id { get; set; }

        //Название группы
        public string Name { get; set; }

        //Состав
        public ICollection<string> Members { get; } = new List<string>();

        //Жанр
        public string Genre { get; set; }
    }
}