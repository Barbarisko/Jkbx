using System.Runtime.Serialization;

namespace Business.Models
{
    [DataContract]
    public class SongModel
    {
        [DataMember]
        private string name;
        [DataMember]
        private string genre;
        [DataMember]
        private string singer;
        [DataMember]
        private decimal duration;

        public string Name { get { return name; } set { name = value; } }
        public string Genre { get { return genre; } set { genre = value; } }
        public string Singer { get { return singer; } set { singer = value; } }
        public decimal Duration { get { return duration; } set { duration = value; } }

        public SongModel()
        {

        }
    }
}