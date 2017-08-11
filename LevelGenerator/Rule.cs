using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;

namespace LevelGenerator
{
    class Rule
    {
        public string Name { get; private set; }
        public Graph RightSide { get; private set; }
        public Graph LeftSide { get; private set; }

        public void SetRule(string name, Graph leftSide, Graph rightSide)
        {
            Name = name;
            LeftSide = leftSide;
            RightSide = rightSide;
        }
    }
}
