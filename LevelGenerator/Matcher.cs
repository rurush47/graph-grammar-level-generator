using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Msagl.Drawing;

namespace LevelGenerator
{
    public class Matcher
    {
        private List<Node> _mNodes = new List<Node>();
        private List<Edge> mEdges = new List<Edge>();
        public List<Match> Matches = new List<Match>();

        public bool CheckSubgraphPresent(Rule rule, Graph graph)
        {
            bool compareReturnValue = false;

            foreach (Node node in graph.Nodes.ToList())
            {
                if (node.NodeSymbol == rule.LeftSide.Nodes.ToArray()[0].NodeSymbol)
                {
                    if (Compare(rule.LeftSide.Nodes.ToArray()[0], node, rule.LeftSide, new List<Edge>()))
                    {
                        compareReturnValue = true;

                        Match newMatch = new Match();
                        newMatch.Edges = mEdges;
                        newMatch.Nodes = _mNodes;
                        mEdges = new List<Edge>();
                        _mNodes = new List<Node>();
                        Matches.Add(newMatch);
                    }
                }
            }

            return compareReturnValue;
        }

        private bool Compare(Node ruleNode, Node mainNode, Graph ruleLeft, List<Edge> visitedEdges)
        {
            if (ruleNode.NodeSymbol != mainNode.NodeSymbol)
                return false;

            _mNodes.Add(mainNode);
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
                    if (/*ruleEdge.TightCoupling == mainEdge.TightCoupling && */
                        Compare(ruleEdge.TargetNode, mainEdge.TargetNode, ruleLeft, visitedEdges))
                    {
                        mEdges.Add(mainEdge);
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
