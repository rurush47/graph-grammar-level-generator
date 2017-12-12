using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NecrodancerGenerator;

namespace NecrodancerLevelGenerator
{
    public class XmlContainers
    {
        [XmlRoot(ElementName = "tile"), Serializable]
        public class Tile : RoomObject
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "zone")]
            public string Zone { get; set; }
            [XmlAttribute(AttributeName = "torch")]
            public string Torch { get; set; }
            [XmlAttribute(AttributeName = "cracked")]
            public string Cracked { get; set; }
        }

        [XmlRoot(ElementName = "tiles"), Serializable]
        public class Tiles
        {
            [XmlElement(ElementName = "tile")]
            public List<Tile> Tile { get; set; }
        }

        [XmlRoot(ElementName = "trap"), Serializable]
        public class Trap : RoomObject
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "subtype")]
            public string Subtype { get; set; }
        }

        [XmlRoot(ElementName = "traps"), Serializable]
        public class Traps
        {
            [XmlElement(ElementName = "trap")]
            public List<Trap> Trap { get; set; }
        }

        [XmlRoot(ElementName = "enemy"), Serializable]
        public class Enemy : RoomObject
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "beatDelay")]
            public string BeatDelay { get; set; }
            [XmlAttribute(AttributeName = "lord")]
            public string Lord { get; set; }
        }

        [XmlRoot(ElementName = "enemies"), Serializable]
        public class Enemies
        {
            [XmlElement(ElementName = "enemy")]
            public List<Enemy> Enemy { get; set; }
        }

        [XmlRoot(ElementName = "item"), Serializable]
        public class Item : RoomObject
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "bloodCost")]
            public string BloodCost { get; set; }
            [XmlAttribute(AttributeName = "saleCost")]
            public string SaleCost { get; set; }
            [XmlAttribute(AttributeName = "singleChoice")]
            public string SingleChoice { get; set; }
        }

        [XmlRoot(ElementName = "items"), Serializable]
        public class Items
        {
            [XmlElement(ElementName = "item")]
            public List<Item> Item { get; set; }
        }

        [XmlRoot(ElementName = "chest"), Serializable]
        public class Chest : RoomObject
        {
            [XmlAttribute(AttributeName = "saleCost")]
            public string SaleCost { get; set; }
            [XmlAttribute(AttributeName = "singleChoice")]
            public string SingleChoice { get; set; }
            [XmlAttribute(AttributeName = "color")]
            public string Color { get; set; }
            [XmlAttribute(AttributeName = "hidden")]
            public string Hidden { get; set; }
            [XmlAttribute(AttributeName = "contents")]
            public string Contents { get; set; }
        }

        [XmlRoot(ElementName = "chests"), Serializable]
        public class Chests
        {
            [XmlElement(ElementName = "chest")]
            public List<Chest> Chest { get; set; }
        }

        [XmlRoot(ElementName = "crate"), Serializable]
        public class Crate : RoomObject
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "contents")]
            public string Contents { get; set; }
        }

        [XmlRoot(ElementName = "crates"), Serializable]
        public class Crates
        {
            [XmlElement(ElementName = "crate")]
            public List<Crate> Crate { get; set; }
        }

        [XmlRoot(ElementName = "shrine"), Serializable]
        public class Shrine : RoomObject
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
        }

        [XmlRoot(ElementName = "shrines"), Serializable]
        public class Shrines
        {
            [XmlElement(ElementName = "shrine")]
            public List<Shrine> Shrine { get; set; }
        }

        [XmlRoot(ElementName = "level"), Serializable]
        public class Level
        {
            [XmlElement(ElementName = "tiles")]
            public Tiles Tiles { get; set; }
            [XmlElement(ElementName = "traps")]
            public Traps Traps { get; set; }
            [XmlElement(ElementName = "enemies")]
            public Enemies Enemies { get; set; }
            [XmlElement(ElementName = "items")]
            public Items Items { get; set; }
            [XmlElement(ElementName = "chests")]
            public Chests Chests { get; set; }
            [XmlElement(ElementName = "crates")]
            public Crates Crates { get; set; }
            [XmlElement(ElementName = "shrines")]
            public Shrines Shrines { get; set; }
            [XmlAttribute(AttributeName = "bossNum")]
            public string BossNum { get; set; }
            [XmlAttribute(AttributeName = "music")]
            public string Music { get; set; }
            [XmlAttribute(AttributeName = "num")]
            public string Num { get; set; }
        }

        [XmlRoot(ElementName = "dungeon"), Serializable]
        public class Dungeon
        {
            [XmlElement(ElementName = "level")]
            public List<Level> Level { get; set; }
            [XmlAttribute(AttributeName = "character")]
            public string Character { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "numLevels")]
            public string NumLevels { get; set; }
        }
    }
}