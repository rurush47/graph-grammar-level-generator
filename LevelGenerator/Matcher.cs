using System.Collections.Generic;
using System.Linq;
using Microsoft.Msagl.Drawing;

namespace LevelGenerator
{
    public class Matcher
    {
        private Dictionary<int, Node> _mNodes = new Dictionary<int, Node>();
        public List<Match> Matches = new List<Match>();

        public bool CheckSubgraphPresent(Rule rule, Graph graph)
        {
            bool compareReturnValue = false;

            foreach (Node node in graph.Nodes.ToList())
            {
                if (node.NodeSymbol == rule.LeftSide.Nodes.ToArray()[0].NodeSymbol)
                {
                    if (Compare(rule.LeftSide.Nodes.ToArray()[0], node, new List<Edge>()))
                    {
                        compareReturnValue = true;

                        Match newMatch = new Match();
                        newMatch.Nodes = _mNodes;
                        _mNodes = new Dictionary<int, Node>();
                        Matches.Add(newMatch);
                    }
                    _mNodes = new Dictionary<int, Node>();
                }
            }

            return compareReturnValue;
        }

        private bool Compare(Node ruleNode, Node mainNode, List<Edge> visitedEdges)
        {
            if (ruleNode.NodeSymbol != mainNode.NodeSymbol)
                return false;

            if (ruleNode.RuleNodeID >= 0)
            {
                _mNodes.Add(ruleNode.RuleNodeID, mainNode);
            }

            foreach (Edge ruleEdge in ruleNode.OutEdges.ToList())
            {
                if (visitedEdges.Contains(ruleEdge))
                {
                    continue;
                }
                bool matched = false;
                foreach (Edge mainEdge in mainNode.OutEdges.ToList())
                {
                    visitedEdges.Add(ruleEdge);
                    if (Compare(ruleEdge.TargetNode, mainEdge.TargetNode, visitedEdges))
                    {
                        matched = true;
                        break;
                    }
                }
                if (matched == false)
                    return false;
            }
            return true;
        }
    }
}
