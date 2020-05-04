using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Song:IDentity
    {
        private string name;
        private string genre;
        private string singer;
        private decimal duration;

        public int SongId { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public string Genre { get { return genre; } set { genre = value; } }
        public string Singer { get { return singer; } set { singer = value; } }
        public decimal Duration { get { return duration; } set { duration = value; } }
        

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
