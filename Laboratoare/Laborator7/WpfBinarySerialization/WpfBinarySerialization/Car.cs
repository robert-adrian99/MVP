using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WpfBinarySerialization
{
    [Serializable]
    class Car : ISerializable
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Owner Owner { get; set; }

        public Car()
        {
        }

        //constructor folosit pentru deserializare
        public Car(SerializationInfo info, StreamingContext ctxt)
        {
            Make = (string)info.GetValue("Make", typeof(string));
            Model = (string)info.GetValue("Model", typeof(string));
            Year = (int)info.GetValue("Year", typeof(int));
            Owner = (Owner)info.GetValue("Owner", typeof(Owner));
        }

        //metoda folosita la serializare
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Make", Make);
            info.AddValue("Model", Model);
            info.AddValue("Year", Year);
            info.AddValue("Owner", Owner);
        }
    }
}
