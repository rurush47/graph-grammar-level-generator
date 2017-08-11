using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;

namespace LevelGenerator
{
    public partial class Form1 : Form
    {
        private Graph _leftGraph;

        public Form1()
        {
            InitializeComponent();

            _leftGraph = new Graph();
            _leftGraph.AddEdge("1", "2");

            gViewerLeft.Graph = _leftGraph;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
