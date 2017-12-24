using System;
using System.Collections.Generic;
using LevelGenerator.Serialization;

namespace LevelGenerator
{
    [Serializable]
    public class ProductionSet
    {
        public List<SerializedRule> Rules;
        public List<string> Symbols;

        public ProductionSet()
        {

        }

        public ProductionSet(List<SerializedRule> rules, List<string> symbols)
        {
            Rules = rules;
            Symbols = symbols;
        }
    }
}
