using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Color = System.Drawing.Color;

namespace LevelGenerator
{
    public partial class Form1 : Form
    {
        private Graph _leftGraph;
        private Graph _rightGraph;
        private Graph _productionGraph;
        private GViewer _currentGViewer;
        private List<Rule> _rules = new List<Rule>();

        public Form1()
        {
            InitializeComponent();

            _currentGViewer = gViewerLeft;
            panelLeftGraph.BackColor = Color.LightPink;

            _productionGraph = new Graph();
            _leftGraph = new Graph();
            _rightGraph = new Graph();

            gViewerLeft.Graph = _leftGraph;
            gViewerRight.Graph = _rightGraph;

            Node startNode = new Node(_productionGraph.GetNewID().ToString());
            startNode.NodeSymbol = "S";
            startNode.Label.Text = "S";
            _productionGraph.AddNode(startNode);

            gViewerProduction.Graph = _productionGraph;
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
            int nodeNumber = GetNumberFromTextBox(tBNodeNumber);

            Node newNode = new Node(g.GetNewID().ToString());

            newNode.RuleNodeID = nodeNumber;
            newNode.NodeSymbol = text;

            newNode.LabelText = nodeNumber == -1 ? text : nodeNumber + ":" + text;

            _currentGViewer.Graph.AddNode(newNode);
            _currentGViewer.Graph = g;

            tBNodeNumber.Text = "";
        }

        private void gViewerRight_Click(object sender, EventArgs e)
        {
            FocusRightSide();
        }

        private void gViewerLeft_Click(object sender, EventArgs e)
        {
            FocusLeftSide();
        }

        private void FocusLeftSide()
        {
            _currentGViewer = gViewerLeft;
            panelLeftGraph.BackColor = Color.LightPink;
            panelRightGraph.BackColor = Color.White;
        }

        private void FocusRightSide()
        {
            _currentGViewer = gViewerRight;
            panelRightGraph.BackColor = Color.LightPink;
            panelLeftGraph.BackColor = Color.White;
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
            SaveRuleToList(text);
        }

        private void SaveRuleToList(string text)
        {
            if (text == null) return;

            Rule rule = new Rule();
            Graph leftSide = gViewerLeft.Graph;
            Graph rightSide = gViewerRight.Graph;
            rule.SetRule(text, leftSide, rightSide);

            //Overwrite rule
            Rule listRule = _rules.Find(r => r.Name == text);
            if (listRule != null)
            {
                //TODO add question prompt
                _rules.Remove(listRule);
            }
            _rules.Add(rule.CloneRule());

            SetRuleFocus(rule);
            //lBRules.SelectedIndex = _rules.IndexOf(rule) + 1;
            RefreshListBox(lBRules, _rules);
        }

        private void SetRuleFocus(Rule rule)
        {
            Rule r = rule.CloneRule();
            _leftGraph = r.LeftSide;
            _rightGraph = r.RightSide;
            gViewerLeft.Graph = _leftGraph;
            gViewerRight.Graph = _rightGraph;
        }

        private static void RefreshListBox<T>(ListControl lb, List<T> dataSource, string displayMember = "Name")
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
                SetRuleFocus(r);
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
            SetBlankRule();
        }

        private void SetBlankRule()
        {
            Rule r = new Rule();
            r.SetRule("", new Graph(), new Graph());
            _leftGraph = r.LeftSide;
            _rightGraph = r.RightSide;
            gViewerLeft.Graph = _leftGraph;
            gViewerRight.Graph = _rightGraph;
        }

        private int GetNumberFromTextBox(TextBox tb)
        {
            int number;
            try
            {
                number = Int32.Parse(tb.Text);
            }
            catch (FormatException)
            {
                return -1;
            }
            if (number < 0)
            {
                return -1;
            }
            return number;
        }

        private void buttonApplyRule_Click(object sender, EventArgs e)
        {
            Graph targetGraph = _productionGraph;
            Rule currentRule = GetItemFromListBox<Rule>(lBRules);

            Matcher matcher = new Matcher();
            matcher.CheckSubgraphPresent(currentRule, targetGraph);

            if (matcher.Matches.Count == 0)
            {
                ShowMessage("No matches found in mission graph!");
                return;
            }

            Random r = new Random();
            int randomIndex = r.Next(0, matcher.Matches.Count - 1);

            Match m = matcher.Matches[randomIndex];

            Replacer.ReplaceNodesWithARule(targetGraph, currentRule, m);

            //TODO make a method for that
            foreach (Node node in targetGraph.Nodes)
            {
                node.Label.Text = node.NodeSymbol;
            }
            foreach (Edge edge in targetGraph.Edges)
            {
                edge.Label.Text = " ";
            }

            _productionGraph = targetGraph;
            gViewerProduction.Graph = _productionGraph;
        }

        private void bSaveRules_Click(object sender, EventArgs e)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Rule.SerializedRule>));

            List<Rule.SerializedRule> ruleList = new List<Rule.SerializedRule>();
            foreach (Rule rule in _rules)
            {
                Rule.SerializedRule sr = new Rule.SerializedRule();
                sr.Serialize(rule);
                ruleList.Add(sr);
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML file|*.xml";
            saveFileDialog1.Title = "Save as XML";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                x.Serialize(fs, ruleList);
                fs.Close();
            }
        }

        private void bLoadRules_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Rule.SerializedRule>));
            List<Rule.SerializedRule> serializedRules = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML file|*.xml";
            openFileDialog1.Title = "Open XML";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                    System.IO.StreamReader(openFileDialog1.FileName);
                serializedRules = (List<Rule.SerializedRule>)xs.Deserialize(sr);
                sr.Close();
            }

            List<Rule> rules = new List<Rule>();
            foreach (Rule.SerializedRule serializedRule in serializedRules)
            {
                rules.Add(serializedRule.Deserialize());
            }

            _rules = rules;
            RefreshListBox(lBRules, rules);
        }

        private void bDeleteRule_Click(object sender, EventArgs e)
        {
            Rule toDelete = GetItemFromListBox<Rule>(lBRules);
            _rules.Remove(toDelete);
            RefreshListBox(lBRules, _rules);
            SetBlankRule();
        }

        private void panelRightGraph_Click(object sender, EventArgs e)
        {
            FocusRightSide();
        }

        private void panelLeftGraph_Click(object sender, EventArgs e)
        {
            FocusLeftSide();
        }

        private void bSaveProduction_Click(object sender, EventArgs e)
        {
            XmlSerializer x = new XmlSerializer(typeof(SerializedGraph));
            SerializedGraph sg = new SerializedGraph();
            sg.Serialize(_productionGraph);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML file|*.xml";
            saveFileDialog1.Title = "Save as XML";
            saveFileDialog1.ShowDialog();
  
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                x.Serialize(fs, sg);
                fs.Close();
            }
        }

        private void bLoadProduction_Click(object sender, EventArgs e)
        {
            XmlSerializer x = new XmlSerializer(typeof(SerializedGraph));

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML file|*.xml";
            openFileDialog1.Title = "Open XML";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                    System.IO.StreamReader(openFileDialog1.FileName);
                SerializedGraph sg = (SerializedGraph)x.Deserialize(sr);
                sr.Close();

                _productionGraph = sg.Deserialize();
                gViewerProduction.Graph = _productionGraph;
            }
        }
    }
}
