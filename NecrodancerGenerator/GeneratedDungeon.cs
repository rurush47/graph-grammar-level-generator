using System.Collections.Generic;
using NecrodancerLevelGenerator;

namespace NecrodancerGenerator
{
    public class GeneratedDungeon
    {
        private XmlContainers.Level _level;

        public GeneratedDungeon(List<Room> rooms, List<Corridor> corridors = null)
        {
            _level = GetEmptyLevel();

            foreach (Room room in rooms)
            {
                _level.Chests.Chest.AddRange(room.Level.Chests.Chest);
                _level.Tiles.Tile.AddRange(room.Level.Tiles.Tile);
                _level.Crates.Crate.AddRange(room.Level.Crates.Crate);
                _level.Enemies.Enemy.AddRange(room.Level.Enemies.Enemy);
                _level.Items.Item.AddRange(room.Level.Items.Item);
                _level.Shrines.Shrine.AddRange(room.Level.Shrines.Shrine);
                _level.Traps.Trap.AddRange(room.Level.Traps.Trap);
            }

            if (corridors != null)
            {
                foreach (Corridor corridor in corridors)
                {
                    _level.Tiles.Tile.AddRange(corridor.Tiles);
                }
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

        public static XmlContainers.Level GetEmptyLevel()
        {

            XmlContainers.Level level = new XmlContainers.Level();

            level.Chests = new XmlContainers.Chests();
            level.Tiles = new XmlContainers.Tiles();
            level.Crates = new XmlContainers.Crates();
            level.Enemies = new XmlContainers.Enemies();
            level.Items = new XmlContainers.Items();
            level.Shrines = new XmlContainers.Shrines();
            level.Traps = new XmlContainers.Traps();

            level.Chests.Chest = new List<XmlContainers.Chest>();
            level.Tiles.Tile = new List<XmlContainers.Tile>();
            level.Crates.Crate = new List<XmlContainers.Crate>();
            level.Enemies.Enemy = new List<XmlContainers.Enemy>();
            level.Items.Item = new List<XmlContainers.Item>();
            level.Shrines.Shrine = new List<XmlContainers.Shrine>();
            level.Traps.Trap = new List<XmlContainers.Trap>();

            return level;
        }
    }
}
