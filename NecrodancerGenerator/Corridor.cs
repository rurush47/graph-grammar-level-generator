using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
            IntVector2 sideVec;
            IntVector2 sideVec2;
            List<IntVector2> corridorVectors = new List<IntVector2>(); ;
            int road;

            if (dir.Equals(IntVector2.up))
            {
                wallSize = sourceRect.Width;
                startVec = new IntVector2(sourceRect.X + wallSize/2, sourceRect.Y);
                road = (targetRect.Y - targetRect.Height) - sourceRect.Y;
                sideVec = startVec + IntVector2.left;
                sideVec2 = startVec + IntVector2.right;
            }
            else if(dir.Equals(IntVector2.down))
            {
                wallSize = sourceRect.Width;
                startVec = new IntVector2(sourceRect.X + wallSize / 2, sourceRect.Y - sourceRect.Height);
                road = (sourceRect.Y - sourceRect.Height) - targetRect.Y;
                sideVec = startVec + IntVector2.left;
                sideVec2 = startVec + IntVector2.right;
            }
            else if(dir.Equals(IntVector2.left))
            {
                wallSize = sourceRect.Height;
                startVec = new IntVector2(sourceRect.X, sourceRect.Y - wallSize / 2);
                road = sourceRect.X - (targetRect.X + targetRect.Width);
                sideVec = startVec + IntVector2.up;
                sideVec2 = startVec + IntVector2.down;
            }
            else
            {
                wallSize = sourceRect.Height;
                startVec = new IntVector2(sourceRect.X + sourceRect.Width, sourceRect.Y - wallSize / 2);
                road = targetRect.X - (sourceRect.X + sourceRect.Width);
                sideVec = startVec + IntVector2.up;
                sideVec2 = startVec + IntVector2.down;
            }

            corridorVectors = new List<IntVector2>()
            {
                startVec,
                sideVec,
                sideVec2
            };

            if (source.Name.Contains("shovelLock"))
            {
                for (int i = 0; i < corridorVectors.Count; i++)
                {
                    corridorVectors[i] += dir;
                }
            }
            if (target.Name.Contains("shovelLock"))
            {
                road -= 1;
            }

            for (int i = 0; i <= road; i++)
            {
                for (int j = 0; j < corridorVectors.Count; j ++)
                {
                    IntVector2 vector = corridorVectors[j];
                    XmlContainers.Tile newTile = new XmlContainers.Tile();
                    newTile.X = vector.X.ToString();
                    newTile.Y = vector.Y.ToString();
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
                                t.X == vector.X.ToString() &&
                                t.Y == vector.Y.ToString());
                        source.Level.Tiles.Tile.Remove(tile);
                    }
                    else if (i == road)
                    {
                        XmlContainers.Tile tile = target
                            .Level
                            .Tiles
                            .Tile
                            .FirstOrDefault(t =>
                                t.X == vector.X.ToString() &&
                                t.Y == vector.Y.ToString());
                        source.Level.Tiles.Tile.Remove(tile);
                    }
                    Tiles.Add(newTile);
                    corridorVectors[j] += dir;
                }
            }
        }
    }
}
