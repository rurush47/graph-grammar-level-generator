using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NecrodancerLevelGenerator;

namespace NecrodancerGenerator
{
    public class Corridor
    {
        public List<XmlContainers.Tile> Tiles = new List<XmlContainers.Tile>();
        public List<XmlContainers.Enemy> Enemies = new List<XmlContainers.Enemy>();

        public Corridor(Room source, Room target, IntVector2 dir)
        {
            //dir -> parent - child | building form child to parent
            Rectangle sourceRect = source.Rectangle;
            Rectangle targetRect = target.Rectangle;

            int wallSize;
            IntVector2 startVec;
            int road;

            if (dir.Equals(IntVector2.up))
            {
                wallSize = sourceRect.Width;
                startVec = new IntVector2(sourceRect.X + wallSize/2, sourceRect.Y);
                road = (targetRect.Y - targetRect.Height) - sourceRect.Y;
            }
            else if(dir.Equals(IntVector2.down))
            {
                wallSize = sourceRect.Width;
                startVec = new IntVector2(sourceRect.X + wallSize / 2, sourceRect.Y - sourceRect.Height);
                road = (sourceRect.Y - sourceRect.Height) - targetRect.Y;
            }
            else if(dir.Equals(IntVector2.left))
            {
                wallSize = sourceRect.Height;
                startVec = new IntVector2(sourceRect.X, sourceRect.Y - wallSize / 2);
                road = sourceRect.X - (targetRect.X + targetRect.Width);
            }
            else
            {
                wallSize = sourceRect.Height;
                startVec = new IntVector2(sourceRect.X + sourceRect.Width, sourceRect.Y - wallSize / 2);
                road = targetRect.X - (sourceRect.X + sourceRect.Width);
            }

            // i == road juz nalezy do room
            for (int i = 0; i <= road; i++)
            {
                XmlContainers.Tile newTile = new XmlContainers.Tile();
                newTile.X = startVec.X.ToString();
                newTile.Y = startVec.Y.ToString();
                newTile.Cracked = "0";
                newTile.Torch = "0";
                newTile.Type = "0";
                newTile.Zone = "0";

                if (i == 0)
                {
                    XmlContainers.Tile tile = source
                        .Level
                        .Tiles
                        .Tile
                        .FirstOrDefault(t =>
                            t.X == startVec.X.ToString() &&
                            t.Y == startVec.Y.ToString());
                    source.Level.Tiles.Tile.Remove(tile);
                }
                else if(i == road)
                {
                    XmlContainers.Tile tile = target
                        .Level
                        .Tiles
                        .Tile
                        .FirstOrDefault(t =>
                            t.X == startVec.X.ToString() &&
                            t.Y == startVec.Y.ToString());
                    source.Level.Tiles.Tile.Remove(tile);
                }
                Tiles.Add(newTile);
                startVec += dir;
            }
        }
    }
}
