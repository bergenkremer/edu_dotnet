using MusicTour.Domain.Contracts;
using System.Collections.Generic;

namespace MusicTour.Domain
{
    //Информация о группе
    public class Band 
    {
        public int Id { get; set; }
        
        //Название группы
        public string Name { get; set; }

        //Состав
        public ICollection<string> Members { get; set; } = new List<string>();

        //Жанр
        public string Genre { get; set; }
    }
}