﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace NecrodancerGenerator
{
    [Serializable]
    public class Room
    {
        public string Name { get; set; }
        public XmlContainers.Level Level;
        public Rectangle Rectangle;
        public IntVector2 Position { get; set; }

        public Room()
        {
            
        }

        public Room(string name, XmlContainers.Dungeon d)
        {
            Name = name;
            Level = d.Level[0];
            SetRectangle();
        }

        public void SetRectangle()
        {
            int xMin = Level.Tiles.Tile.Select(t => Int32.Parse(t.X)).ToList().Min(x => x);
            int yMin = Level.Tiles.Tile.Select(t => Int32.Parse(t.Y)).ToList().Min(y => y);
            int xMax = Level.Tiles.Tile.Select(t => Int32.Parse(t.X)).ToList().Max(x => x);
            int yMax = Level.Tiles.Tile.Select(t => Int32.Parse(t.Y)).ToList().Max(y => y);

            int width = xMax - xMin;
            int height = yMax - yMin;

            Rectangle = new Rectangle(xMin, yMax, width, height);
            Position = new IntVector2(xMin, yMin);
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

        public int GetMaxDimension()
        {
            return Math.Max(Rectangle.Width, Rectangle.Height);
        }
    }
}
