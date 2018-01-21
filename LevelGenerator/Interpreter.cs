using System;
using System.Collections.Generic;
using System.Configuration;

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
        
        public Interpreter()
        {
            
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