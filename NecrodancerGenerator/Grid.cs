using NecrodancerLevelGenerator;

namespace NecrodancerGenerator
{
    public class Cell
    {
        public Room room;
    }

    public class Grid
    {
        private Cell[,] _cells;

        public Grid(int size)
        {
            _cells = new Cell[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _cells[i, j] = new Cell();
                }
            }
        }

        public void AppendNewRoom(IntVector2 parentPos, Room room)
        {
            //change room pos here !!!
        }

        public void AppendStartRoom(IntVector2 pos, Room room)
        {
            
        }
    }
}
