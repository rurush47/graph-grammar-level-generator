using System;
using System.Collections.Generic;

namespace NecrodancerGenerator
{
    [Serializable]
    public class IntVector2
    {
        public int X;
        public int Y;

        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static IntVector2 operator -(IntVector2 v1, IntVector2 v2) =>
            new IntVector2(v1.X - v2.X, v1.Y - v2.Y);

        public static IntVector2 operator +(IntVector2 v1, IntVector2 v2) =>
            new IntVector2(v1.X + v2.X, v1.Y + v2.Y);

        public static IntVector2 operator *(IntVector2 v1, int i) =>
            new IntVector2(v1.X * i, v1.Y * i);

        public bool Equals(IntVector2 other)
        {
            return X == other.X && Y == other.Y;
        }

        public static IntVector2 up = new IntVector2(0, 1);
        public static IntVector2 down = new IntVector2(0, -1);
        public static IntVector2 left = new IntVector2(-1, 0);
        public static IntVector2 right = new IntVector2(1, 0);

        public static List<IntVector2> GetDirectionalVectors()
        {
            return new List<IntVector2>()
            {
                up,
                down,
                left,
                right
            };
        }
    }
}
