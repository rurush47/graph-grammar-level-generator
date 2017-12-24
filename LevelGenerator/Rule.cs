using System;
using LevelGenerator.Serialization;
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

        public bool IsValid()
        {
            //TODO implement
            return false;
        }

        public Rule CloneRule()
        {
            SerializedRule r = new SerializedRule();
            r.Serialize(this);
            return r.Deserialize();
        }
    }
}
