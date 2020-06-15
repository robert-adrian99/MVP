using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WpfBinarySerialization
{
    //se creaza o clasa in care se pun toate informatiile pe care dorim sa le serializam
    //in cazul nostru - lista de masini
    //aceasta clasa trebuie sa implementeze si ea interfata ISerializable
    [Serializable]
    class ObjectToSerialize: ISerializable
    {
        public List<Car> Cars { get; set; }

        public ObjectToSerialize() { }

        public ObjectToSerialize(SerializationInfo info, StreamingContext ctxt)
        {
            //functia GetValue recupereaza o valoare din lista de serializari
            //aceasta valoare a fost asociata cu stringul "myCars"
            Cars = (List<Car>)info.GetValue("myCars", typeof(List<Car>));
        }

        //aceasta este o metoda a interfetei ISerializable care trebuie implementata
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //adauga in lista de serializari o valoare care este asociata cu o anumita cheie
            //in acest caz cheia este stringul "myCars"
            info.AddValue("myCars", Cars);
        }
    }
}
