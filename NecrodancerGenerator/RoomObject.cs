using System;
using System.Xml.Serialization;

namespace NecrodancerGenerator
{
    [Serializable]
    public class RoomObject
    {
        [XmlAttribute(AttributeName = "x")]
        public string X { get; set; }
        [XmlAttribute(AttributeName = "y")]
        public string Y { get; set; }

        public void Move(IntVector2 vec)
        {
            X = (int.Parse(X) + vec.X).ToString();
            Y = (int.Parse(Y) + vec.Y).ToString();
        }
    }
}
