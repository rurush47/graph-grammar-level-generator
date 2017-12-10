using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecrodancerGenerator
{
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
    }
}
