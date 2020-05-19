using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WpfBinarySerialization
{
    [Serializable]
    class Owner : ISerializable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Owner()
        {
        }
       
        //constructorul este folosit la deserializare
        public Owner(SerializationInfo info, StreamingContext ctxt)
        {
            FirstName = (string)info.GetValue("first", typeof(string));
            LastName = (string)info.GetValue("last", typeof(string));
        }

        //descrie cum se serializeaza obiectul
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("first", FirstName);
            info.AddValue("last", LastName);
        }
    }
}
