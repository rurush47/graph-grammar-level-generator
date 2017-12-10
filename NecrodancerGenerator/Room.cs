using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NecrodancerGenerator;

public enum Neighbourhood
{
    Left,
    Right,
    Up,
    Down
}

namespace NecrodancerLevelGenerator
{
    [Serializable]
    public class Room
    {
        public string Name { get; set; }
        public XmlContainers.Level Level;
        public Rectangle Rectangle;
        public IntVector2 Position { get; set; }
        public List<Neighbourhood> Neighbours = new List<Neighbourhood>();

        public Room()
        {
            
        }

        public Room(string name, XmlContainers.Dungeon d)
        {
            Name = name;
            Level = d.Level[0];
            SetRectangle();
        }

        //        public bool SetNeighbour(Neighbourhood side, Room neighbour)
        //        {
        //            if (_neighbourhood.ContainsKey(side))
        //            {
        //                _neighbourhood.Add(side, neighbour);
        //            }
        //            return false;
        //        }

        public bool SetNeighbour(Neighbourhood neighbour)
        {
            if (!Neighbours.Contains(neighbour))
            {
                Neighbours.Add(neighbour);
                return true;
            }
            return false;
        }

        public void SetRectangle()
        {
            int xMin = Level.Tiles.Tile.Select(t => Int32.Parse(t.X)).ToList().Min(x => x);
            int yMin = Level.Tiles.Tile.Select(t => Int32.Parse(t.Y)).ToList().Min(y => y);
            int xMax = Level.Tiles.Tile.Select(t => Int32.Parse(t.X)).ToList().Max(x => x);
            int yMax = Level.Tiles.Tile.Select(t => Int32.Parse(t.Y)).ToList().Max(y => y);

            int width = xMax - xMin;
            int height = yMax - yMin;

            Rectangle = new Rectangle(xMin, yMin, width, height);
            Position = new IntVector2(xMin, yMin);
        }

        public void ChangePosition(IntVector2 newPos)
        {
            MoveBy(newPos - Position);
        }

        public void MoveBy(IntVector2 vec)
        {
            foreach (RoomObject roomObject in GetAllRoomObjects())
            {
                roomObject.Move(vec);
            }
            SetRectangle();
        }

        public List<RoomObject> GetAllRoomObjects()
        {
            List<RoomObject> roomObjects = new List<RoomObject>();
            roomObjects.AddRange(Level.Chests.Chest);
            roomObjects.AddRange(Level.Tiles.Tile);
            roomObjects.AddRange(Level.Crates.Crate);
            roomObjects.AddRange(Level.Enemies.Enemy);
            roomObjects.AddRange(Level.Items.Item);
            roomObjects.AddRange(Level.Shrines.Shrine);
            roomObjects.AddRange(Level.Traps.Trap);
            return roomObjects;
        }
    }
}
