using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using GraphTransformationLanguage;
using LevelGenerator.Serialization;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Color = System.Drawing.Color;

namespace LevelGenerator
{
    public enum MatchMode
    {
        Random,
        First
    }
    
    public partial class GraphEditor : Form
    {
        private Graph _leftGraph;
        private Graph _rightGraph;
        private Graph _productionGraph;
        private GViewer _currentGViewer;
        private List<Rule> _rules = new List<Rule>();
        private List<string> _symbols = new List<string>();
        private Matcher _matcher;
        private MatchMode _matchMode = MatchMode.Random;
        private int _minNodes;
        private int _randomGraphIterations = 500;

        public GraphEditor()
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
            startNode.NodeSymbol = "Start";
            startNode.Label.Text = "Start";
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

        private void AddNewNodeToGraph(string text)
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
            AddNewNodeToGraph(text);
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

            try
            {
                rule.IsValid();
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
                return;
            }

            //Overwrite rule
            Rule listRule = _rules.Find(r => r.Name == text);
            if (listRule != null)
            {
                _rules.Remove(listRule);
            }
            _rules.Add(rule.CloneRule());

            SetRuleFocus(rule);
            RefreshListBox(lBRules, _rules);
        }

        private void SetRuleFocus(Rule rule)
        {
            Rule r = rule.CloneRule();
            SetViewerRule(r);
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
            SetViewerRule(r);
        }

        private void SetViewerRule(Rule rule)
        {
            _leftGraph = rule.LeftSide;
            _rightGraph = rule.RightSide;
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
            
            Rule currentRule = GetItemFromListBox<Rule>(lBRules);

            if (currentRule == null)
            {
                ShowMessage("Rule not selected form the listbox!");    
                return;
            }

            if (!ApplyRule(currentRule))
            {
                ShowMessage("No matches found in mission graph!");
            }
        }

        private bool ApplyRule(Rule rule)
        {
            Graph targetGraph = _productionGraph;
            
            _matcher = new Matcher();
            _matcher.CheckSubgraphPresent(rule, targetGraph);

            if (_matcher.Matches.Count == 0)
            {
                return false;
            }

            Match m;
            if (_matchMode == MatchMode.Random)
            {
                Random r = new Random();
                int randomIndex = r.Next(0, _matcher.Matches.Count - 1);
                m = _matcher.Matches[randomIndex];
            }
            else
            {
                m = _matcher.Matches.First();
            }

            Replacer.ReplaceNodesWithARule(targetGraph, rule, m);

            ClearEdgesLabels(targetGraph);

            _productionGraph = targetGraph;
            gViewerProduction.Graph = _productionGraph;

            return true;
        }
        
        private void ClearEdgesLabels(Graph graph)
        {
            foreach (Node node in graph.Nodes)
            {
                if (node.Label != null)
                {
                    node.Label.Text = node.NodeSymbol;
                }
            }
            foreach (Edge edge in graph.Edges)
            {
                if (edge.Label != null)
                {
                    edge.Label.Text = " ";
                }
            }
        }

        private void SaveXML<T>(T dataSource)
        {
            XmlSerializer x = new XmlSerializer(typeof(T));

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML file|*.xml";
            saveFileDialog1.Title = "Save as XML";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                x.Serialize(fs, dataSource);
                fs.Close();
            }
        }

        private object LoadXML<T>()
        {
            T pointer = default(T);
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "XML file|*.xml";
                openFileDialog1.Title = "Open XML";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamReader sr = new
                        System.IO.StreamReader(openFileDialog1.FileName);
                    pointer = (T)xs.Deserialize(sr);
                    sr.Close();
                    return pointer;
                }
            }
            catch (Exception e)
            {
                ShowMessage("Couldn't load XML");
            }
            return pointer;
        }

        private void bSaveRules_Click(object sender, EventArgs e)
        {
            List<SerializedRule> ruleList = new List<SerializedRule>();
            foreach (Rule rule in _rules)
            {
                SerializedRule sr = new SerializedRule();
                sr.Serialize(rule);
                ruleList.Add(sr);
            }
            ProductionSet ps = new ProductionSet(ruleList, _symbols);

            SaveXML(ps);
        }

        private void bLoadRules_Click(object sender, EventArgs e)
        {
            ProductionSet ps = (ProductionSet)LoadXML<ProductionSet>();
            if (ps == null) return;

            List<Rule> rules = new List<Rule>();
            foreach (SerializedRule serializedRule in ps.Rules)
            {
                rules.Add(serializedRule.Deserialize());
            }

            _rules = rules;
            RefreshListBox(lBRules, rules);

            _symbols = ps.Symbols;
            RefreshListBox(lBSymbols, _symbols);
            RefreshListBox(cBSymbols, _symbols);
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
            SerializedGraph sg = new SerializedGraph();
            sg.Serialize(_productionGraph);
            SaveXML(sg);
        }

        private void bLoadProduction_Click(object sender, EventArgs e)
        {
            SerializedGraph sg = (SerializedGraph)LoadXML<SerializedGraph>();
            if (sg == null) return;

            _productionGraph = sg.Deserialize();
            gViewerProduction.Graph = _productionGraph;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string symbol = GetTextFromTextBox(tBSymbolName);
            if (symbol != null)
            {
                if (!_symbols.Contains(symbol))
                {
                    _symbols.Add(symbol);
                    RefreshListBox(lBSymbols, _symbols);
                    RefreshListBox(cBSymbols, _symbols);
                    tBSymbolName.Text = "";
                }
            }
        }

        private void bDeleteSymbol_Click(object sender, EventArgs e)
        {
            string toDelete = GetItemFromListBox<string>(lBSymbols);
            _symbols.Remove(toDelete);
            RefreshListBox(lBSymbols, _symbols);
            RefreshListBox(cBSymbols, _symbols);
        }

        private void cBSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            tBNewNode.Text = GetItemFromListBox<string>(cBSymbols);
        }

        private void bLoadScript_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExecuteScript(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    ShowMessage("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void GenerateRanomGraph()
        {
            Random r = new Random();
            for (int i = 0; i < _randomGraphIterations; i++)
            {
                if (_productionGraph.Nodes.Count() >= _minNodes)
                {
                    return;                    
                }
                int randomIndex = r.Next(0, _rules.Count - 1);
                Rule randomRule = _rules[randomIndex];
                ApplyRule(randomRule);
            }
        }
        
        private void ExecuteScript(string path)
        {
            Source source = new Source(path);
            Lexer lexer = new Lexer(source);
            Parser parser = new Parser(lexer);
            Interpreter interpreter = new Interpreter();
                    
            parser.ParseFile();

            interpreter.CheckConfig(parser.Config);
            if (parser.FixedProduction)
            {
                interpreter.CheckProduction(
                    parser.Rules.Select(r => r.Name).ToList(),
                    parser.Production);    
            }
                    
            _productionGraph = parser.StartGraph;
            _rules = parser.Rules.ConvertAll((input =>
            {
                Rule r = new Rule();
                r.SetRule(input.Name, input.LeftSide, input.RightSide);
                return r;
            }));

            foreach (Node node in _productionGraph.Nodes)
            {
                node.Label.Text = node.NodeSymbol;
            }

            if (parser.FixedProduction)
            {
                foreach (string productionName in parser.Production)
                {
                    if (ApplyRule(
                        _rules.FirstOrDefault(r => r.Name == productionName))) continue;
                    ShowMessage("Rules provided in specified order cannot be applied");
                    break;
                }
            }
            else
            {
                _minNodes = interpreter.MinimumNodes;
                _matchMode = interpreter.MatchMode;

                if (_minNodes > 0)
                {
                    GenerateRanomGraph();
                }
            }
            
            gViewerProduction.Graph = _productionGraph;
            RefreshListBox(lBRules, _rules);
        }
    }
}
