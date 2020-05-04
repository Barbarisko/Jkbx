using System.Collections.Generic;

namespace Data.Entities
{
   public class Album:IDentity
    {
        private string name;
        private List<Song> songs;
        private string releasedate;
        private decimal price;

        public int AlbumId { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public string Releasedate { get { return releasedate; } set { releasedate = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public List<Song> Songs { get { return songs; } set { songs = value; } }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
