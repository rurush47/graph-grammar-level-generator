using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NecrodancerLevelGenerator;

namespace NecrodancerGenerator
{
    public class GeneratedDungeon
    {
        private XmlContainers.Dungeon _dungeon;
        private XmlContainers.Level _level;

        public GeneratedDungeon(List<Room> rooms)
        {
            _level = new XmlContainers.Level();

            _level.Chests = new XmlContainers.Chests();
            _level.Tiles = new XmlContainers.Tiles();
            _level.Crates = new XmlContainers.Crates();
            _level.Enemies = new XmlContainers.Enemies();
            _level.Items = new XmlContainers.Items();
            _level.Shrines = new XmlContainers.Shrines();
            _level.Traps = new XmlContainers.Traps();

            _level.Chests.Chest = new List<XmlContainers.Chest>();
            _level.Tiles.Tile = new List<XmlContainers.Tile>();
            _level.Crates.Crate = new List<XmlContainers.Crate>();
            _level.Enemies.Enemy = new List<XmlContainers.Enemy>();
            _level.Items.Item = new List<XmlContainers.Item>();
            _level.Shrines.Shrine = new List<XmlContainers.Shrine>();
            _level.Traps.Trap = new List<XmlContainers.Trap>();

            foreach (Room room in rooms)
            {
                room.MoveBy(new IntVector2(-3, -3));


                _level.Chests.Chest.AddRange(room.Level.Chests.Chest);
                _level.Tiles.Tile.AddRange(room.Level.Tiles.Tile);
                _level.Crates.Crate.AddRange(room.Level.Crates.Crate);
                _level.Enemies.Enemy.AddRange(room.Level.Enemies.Enemy);
                _level.Items.Item.AddRange(room.Level.Items.Item);
                _level.Shrines.Shrine.AddRange(room.Level.Shrines.Shrine);
                _level.Traps.Trap.AddRange(room.Level.Traps.Trap);
            }

            _level.BossNum = "-1";
            _level.Music = "1";
            _level.Num = "1";
        }

        public XmlContainers.Dungeon GetXMLDungeon()
        {
            XmlContainers.Dungeon d = new XmlContainers.Dungeon();
            d.Name = "test";
            d.Character = "0";
            d.NumLevels = "1";

            List<XmlContainers.Level> levels = new List<XmlContainers.Level>();  
            levels.Add(_level);
            d.Level = levels;

            return d;
        }
    }
}
