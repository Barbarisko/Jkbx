using Data;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Business.Models
{
    [DataContract]
    public class AlbumModel
    {
        [DataMember]
        private string name;
        [DataMember]
        private List<SongModel> songs;
        [DataMember]
        private string releasedate;
        [DataMember]
        private int price;

        public string Name { get { return name; } set { name = value; } }
        public string Releasedate { get { return releasedate; } set { releasedate = value; } }
        public int Price { get { return price; } set { price = value; } }
        public List<SongModel> Songs { get { return songs; } set { songs = value; } }

        public AlbumModel() { }

        
        
    }
}