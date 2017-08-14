using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Color = System.Drawing.Color;

namespace LevelGenerator
{
    public partial class Form1 : Form
    {
        private Graph _leftGraph;
        private Graph _rightGraph;
        private GViewer _currentGViewer;
        private List<Rule> _rules = new List<Rule>(); 

        public Form1()
        {
            InitializeComponent();

            _currentGViewer = gViewerLeft;
            _leftGraph = new Graph();
            _rightGraph = new Graph();

            gViewerLeft.Graph = _leftGraph;
            gViewerRight.Graph = _rightGraph;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DeleteSelectedNode()
        {
            var al = new ArrayList();
            foreach (IViewerObject ob in _currentGViewer.Entities)
                if (ob.MarkedForDragging)
                    al.Add(ob);
            foreach (IViewerObject ob in al)
            {
                var edge = ob.DrawingObject as IViewerEdge;
                if (edge != null)
                    _currentGViewer.RemoveEdge(edge, true);
                else
                {
                    var node = ob as IViewerNode;
                    if (node != null)
                        _currentGViewer.RemoveNode(node, true);
                }
            }
        }

        private void AddNewNodeToSelectedGraph(string text)
        {
            if (text == null) return;

            Graph g = _currentGViewer.Graph;
            Node newNode = new Node(g.NodeCount.ToString());
            newNode.LabelText = text;
            _currentGViewer.Graph.AddNode(newNode);
            _currentGViewer.Graph = g;
        }

        private void gViewerRight_Click(object sender, EventArgs e)
        {
            _currentGViewer = gViewerRight;
        }

        private void gViewerLeft_Click(object sender, EventArgs e)
        {
            _currentGViewer = gViewerLeft;
        }

        private void buttonDeleteNode_Click(object sender, EventArgs e)
        {
            DeleteSelectedNode();
        }

        private void buttonAddNode_Click(object sender, EventArgs e)
        {
            String text = GetTextFromTextBox(tBNewNode);
            AddNewNodeToSelectedGraph(text);
        }

        private string GetTextFromTextBox(TextBox tb)
        {
            string text = tb.Text;
            if (String.IsNullOrEmpty(text))
            {
                ShowMessage("Text for new node is empty");
                return null;
            }
            return text;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void buttonNewRule_Click(object sender, EventArgs e)
        {
            string text = GetTextFromTextBox(tBNewRule);
            AddNewRule(text);
        }

        private void AddNewRule(string text)
        {
            if (text == null) return;

            Rule rule = new Rule();
            Graph leftSide = new Graph();
            Graph rightSide = new Graph();
            rule.SetRule(text, leftSide, rightSide);
            _rules.Add(rule);

            RefreshListBox(lBRules, _rules, "Name");
            SetNewRule(rule);
        }

        private static void RefreshListBox<T>(ListControl lb, List<T> dataSource, string displayMember)
        {
            lb.DataSource = null;
            lb.DataSource = dataSource;
            lb.DisplayMember = displayMember;
        }

        private void lBRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rule r = GetItemFromListBox<Rule>(lBRules);
            if (r != null)
            {
                SetNewRule(r.LeftSide, r.RightSide);
            }
        }

        private T GetItemFromListBox<T>(ListControl lB)
        {
            int selectedIndex = lB.SelectedIndex;
            if (selectedIndex == -1) return default(T);
            List<T> dataSource = (List<T>) lB.DataSource;
            return dataSource[selectedIndex];
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            SetNewRule(new Graph(), new Graph());
        }

        private void SetNewRule(Graph left, Graph right)
        {
            _leftGraph = left;
            _rightGraph = right;
            gViewerLeft.Graph = _leftGraph;
            gViewerRight.Graph = _rightGraph;
        }

        private void SetNewRule(Rule rule)
        {
            SetNewRule(rule.LeftSide, rule.RightSide);
        }
    }
}
