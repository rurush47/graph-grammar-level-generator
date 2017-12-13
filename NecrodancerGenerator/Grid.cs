using System;
using System.Collections.Generic;
using System.Linq;
using NecrodancerLevelGenerator;

namespace NecrodancerGenerator
{
    public class Cell
    {
        public Room room;
        public IntVector2 gridPos;

        public void AppendRoom(Room room)
        {
            this.room = room;
        }
    }

    public class Grid
    {
        private Dictionary<Room, Cell> roomCells = new Dictionary<Room, Cell>();
        private Cell[,] _cells;
        private int _size;
        private int _cellSize;

        public Grid(int size, int cellSize)
        {
            _size = size;
            _cellSize = cellSize;
            _cells = new Cell[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _cells[i, j] = new Cell();
                    _cells[i, j].gridPos = new IntVector2(i, j);
                }
            }
        }

        public void AppendNewRoom(Room parentRoom, Room room)
        {
            IntVector2 parentGridPos = roomCells[parentRoom].gridPos;

            Cell c = GetPreferedNeighbour(parentGridPos);
            if (c != null)
            {
                c.AppendRoom(room);
                roomCells.Add(room, c);
            }
        }

        public void AppendStartRoom(Room room)
        {
            Cell startCell = _cells[_size / 2, _size / 2];
            startCell.AppendRoom(room);
            roomCells.Add(room, startCell);
        }

        public IntVector2 GetGridCenter()
        {
            return new IntVector2(_size/2, _size/2);
        }

        public int GetEmptyNeighbourCount(IntVector2 pos)
        {
            int count = 0;
            foreach (IntVector2 dir in IntVector2.GetDirectionalVectors())
            {
                int x = pos.X + dir.X;
                int y = pos.Y + dir.Y;

                if (x >= 0 && x < _size && y >= 0 && y < _size &&
                    _cells[x, y].room == null)
                {
                    count++;
                }
            }
            return count;
        }

        private List<Cell> GetEmptyNeighbours(IntVector2 pos)
        {
            List<Cell> cells = new List<Cell>();
            foreach (IntVector2 dir in IntVector2.GetDirectionalVectors())
            {
                int x = pos.X + dir.X;
                int y = pos.Y + dir.Y;

                if (x >= 0 && x < _size && y >= 0 && y < _size &&
                    _cells[x, y].room == null)
                {
                    cells.Add(_cells[x, y]);
                }
            }

            return cells;
        }

        private Cell GetRandomEmptyNeighbour(IntVector2 pos)
        {
            List<Cell> randomNs = GetEmptyNeighbours(pos);
            if (randomNs.Count > 0)
            {
                Random r = new Random();
                return randomNs[r.Next(0, randomNs.Count)];
            }
            return null;
        }

        private Cell GetPreferedNeighbour(IntVector2 pos)
        {
            List<Cell> randomNs = GetEmptyNeighbours(pos);
            if (randomNs.Count > 0)
            {
                Cell bestN = randomNs
                    .OrderByDescending(n => GetEmptyNeighbourCount(n.gridPos))
                    .FirstOrDefault();

                int bestNCount = GetEmptyNeighbourCount(bestN.gridPos);

                List<Cell> bestNs = randomNs
                    .Where(n => GetEmptyNeighbourCount(n.gridPos) == bestNCount)
                    .ToList();

                Random r = new Random();
                return bestNs[r.Next(0, bestNs.Count)];
            }
            return null;
        }

        public List<Cell> GetCells()
        {
            List<Cell> rCells = new List<Cell>();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    rCells.Add(_cells[i, j]);
                }
            }
            return rCells;
        }

        public int GetCellSize()
        {
            return _cellSize;
        }

        public IntVector2 GetRoomPos(Room room)
        {
            if (roomCells.ContainsKey(room))
            {
                return roomCells[room].gridPos;
            }
            return GetGridCenter();
        }
    }
}

