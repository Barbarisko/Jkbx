using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Business.Models
{
    [DataContract]

    public class MachineModel
    {
        [DataMember]
        public List<AlbumModel> albums ;
        //public string pathToOr;      
      
        //~MachineModel()
        //{
        //    saveToFile(pathToOr);
        //}
    }
}
