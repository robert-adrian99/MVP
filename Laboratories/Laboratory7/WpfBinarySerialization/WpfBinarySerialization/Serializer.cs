using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfBinarySerialization
{
    //vom crea o clasa in care vom implementa functiile de serializare si deserializare
    class Serializer
    {
        public void SerializeObject(string filename, ObjectToSerialize objectToSerialize)
        {
            using (Stream stream = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
            }
        }

        public ObjectToSerialize DeserializeObject(string filename)
        {
            ObjectToSerialize objectToSerialize;
            using (Stream stream = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (ObjectToSerialize)bFormatter.Deserialize(stream);
            }
            return objectToSerialize;
        }
    }
}
