using System;
using System.Collections.Generic;

namespace LevelGenerator
{
    [Serializable]
    public class ProductionSet
    {
        public List<Rule.SerializedRule> Rules;
        public List<string> Symbols;

        public ProductionSet(List<Rule.SerializedRule> rules, List<string> symbols)
        {
            Rules = rules;
            Symbols = symbols;
        }

        public ProductionSet()
        {
            
        }
    }
}
