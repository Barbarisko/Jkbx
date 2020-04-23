using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface ISerialize
    {
        void Serialize(Object obj, string path);
        Object Deserialize(string path);
    }

    public class SerializeJson : ISerialize
    {
        DataContractJsonSerializer serializeJson;
        public SerializeJson(Type type)
        {
            serializeJson = new DataContractJsonSerializer(type);

        }

        public void Serialize(Object obj, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializeJson.WriteObject(stream, obj);
            }
        }

        public Object Deserialize(string path)
        {

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return serializeJson.ReadObject(stream);
            }
        }
    }

}
