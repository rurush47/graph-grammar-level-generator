using System;
using System.Collections.Generic;
using System.Linq;
using GraphTransformationLanguage;
using Microsoft.Msagl.Core.Layout;
using Node = Microsoft.Msagl.Drawing.Node;

namespace LevelGenerator
{   
    public class InterpreterExeption : Exception
    {
        public InterpreterExeption(string message)
            : base(message)
        {
            
        }    
    }
    
    public class Interpreter
    {
        private List<Type> _types;
        public int MinimumNodes { get; private set; }
        public MatchMode MatchMode { get; private set; }
        private Parser _parser;
        private GraphEditor _graphEditor;

        public Interpreter(Parser parser, GraphEditor graphEditor)
        {
            _graphEditor = graphEditor;
            _parser = parser;
        }

        public void InterpreteScript()
        {
            _parser.ParseFile();

            CheckConfig(_parser.Config);
            if (_parser.FixedProduction)
            {
                CheckProduction(
                    _parser.Rules.Select(r => r.Name).ToList(),
                    _parser.Production);    
            }
            
            List<Rule> rules = _parser.Rules.ConvertAll((input =>
            {
                Rule r = new Rule();
                r.SetRule(input.Name, input.LeftSide, input.RightSide);
                return r;
            }));
            
            foreach (var rule in rules)
            {
                try
                {
                    rule.IsValid();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            _graphEditor.SetRuleList(rules);
            
            foreach (Node node in _parser.StartGraph.Nodes)
            {
                node.Label.Text = node.NodeSymbol;
            }

            _graphEditor.SetProductionGraph(_parser.StartGraph);
            
            if (_parser.FixedProduction)
            {
                foreach (string productionName in _parser.Production)
                {
                    if (_graphEditor.ApplyRule(
                        rules.FirstOrDefault(r => r.Name == productionName))) continue;
                    _graphEditor.ShowMessage("Rules provided in specified order cannot be applied");
                    break;
                }
            }
            else
            {
                _graphEditor.MinNodes = MinimumNodes;
                _graphEditor.MatchMode = MatchMode;

                if (_graphEditor.MinNodes > 0)
                {
                    _graphEditor.GenerateRanomGraph();
                }
            }
            
            _graphEditor.RefreshProductionView();
        }
        
        public void CheckConfig(Dictionary<string, string> config)
        {
            foreach (var singleConfig in config)
            {
                if (singleConfig.Key == "minimum_nodes")
                {
                    if (int.TryParse(singleConfig.Value, out var nodes))
                    {
                        if (nodes < 0)
                        {
                            throw new InterpreterExeption
                                ("Int value required after minimum_nodes have to be more than 0");        
                        }
                        else
                        {
                            MinimumNodes = nodes;                            
                        }
                    }
                    else
                    {
                        throw new InterpreterExeption
                            ("Int value required after minimum_nodes option");
                    }
                }
                else if (singleConfig.Key == "match_mode")
                {
                    if (singleConfig.Value == "random")
                    {
                        MatchMode = MatchMode.Random;
                    }
                    else if (singleConfig.Value == "first")
                    {
                        MatchMode = MatchMode.First;
                    }
                    else
                    {
                        throw new InterpreterExeption
                            ("Match mode have to be set to random or first.");
                    }
                }
                else
                {
                    throw new InterpreterExeption
                        ("Config name doesn't match any known configuration name");
                }
            }
        }

        public void CheckProduction(List<string> production, List<string> productionNames)
        {
            foreach (string productionName in productionNames)
            {
                if (productionNames.Count == 0)
                {
                    return;
                }
                
                if (!production.Contains(productionName))
                {
                    throw new InterpreterExeption("Production name provided is not present in the rules list!");
                }
            }    
        }
    }
}