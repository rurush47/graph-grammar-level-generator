using System;
using System.Collections.Generic;
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
            //change room pos here !!!
            IntVector2 parentGridPos = roomCells[parentRoom].gridPos;

            Cell c = GetRandomEmptyNeighbour(parentGridPos);
            if (c != null)
            {
                c.AppendRoom(room);
                roomCells.Add(room, c);
            }
            //append corridor here !!!
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

        private int GetEmptyNeighbourCount(IntVector2 pos)
        {
            int count = 0;
            int i = pos.X;
            int j = pos.Y;
            for (int l = i - 1; l <= i + 1; l++)
            {
                for (int m = j - 1; m <= j + 1; m++)
                {
                    if (m >= 0 && l >= 0 && l < _size && m < _size)
                    {
                        if (_cells[l, m].room == null)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private List<Cell> GetEmptyNeighbours(IntVector2 pos)
        {
            List<Cell> cells = new List<Cell>();
            int i = pos.X;
            int j = pos.Y;
            for (int l = i - 1; l <= i + 1; l++)
            {
                for (int m = j - 1; m <= j + 1; m++)
                {
                    if (m >= 0 && l >= 0 && l < _size && m < _size)
                    {
                        if (_cells[l, m].room == null)
                        {
                            cells.Add(_cells[l, m]);
                        }
                    }
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
    }
}

