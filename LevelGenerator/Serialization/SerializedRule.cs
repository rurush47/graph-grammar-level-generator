namespace LevelGenerator.Serialization
{
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
}