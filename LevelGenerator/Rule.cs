using System;
using Microsoft.Msagl.Drawing;

namespace LevelGenerator
{
    [Serializable]
    public class Rule
    {
        public string Name { get; private set; }
        public Graph RightSide { get; private set; }
        public Graph LeftSide { get; private set; }

        public Rule()
        {
            
        }

        public void SetRule(string name, Graph leftSide, Graph rightSide)
        {
            Name = name;
            LeftSide = leftSide;
            RightSide = rightSide;
        }

        public class SerializedRule
        {
            public string Name;
            public SerializedGraph RightSide;
            public SerializedGraph LeftSide;

            public void Serialize(Rule rule)
            {
                Name = rule.Name;
                RightSide = new SerializedGraph();
                RightSide.Serialize(rule.RightSide);
                LeftSide = new SerializedGraph();
                LeftSide.Serialize(rule.LeftSide);
            }

            public Rule Deserialize()
            {
                Rule rule = new Rule();
                rule.SetRule(Name, LeftSide.Deserialize(), RightSide.Deserialize());

                return rule;
            }
        }

        public Rule CloneRule()
        {
            SerializedRule r = new SerializedRule();
            r.Serialize(this);
            return r.Deserialize();
        }
    }
}
