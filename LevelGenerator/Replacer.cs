using System.Collections.Generic;
using System.Linq;
using Microsoft.Msagl.Drawing;

namespace LevelGenerator
{
    public class Replacer
    {
        public static void ReplaceNodesWithARule(Graph graph, Rule rule, Match match)
        {
            List<Node> newNodes = new List<Node>();
            //remove all edges
            foreach (Node node in match.Nodes.Values)
            {
                foreach (Node node2 in match.Nodes.Values)
                {
                    if (!Equals(node, node2))
                    {
                        for (int i = graph.EdgeCount - 1; i >= 0; i--)
                        {
                            Edge e = graph.Edges.ToArray()[i];
                            if (Equals(e.SourceNode, node) && Equals(e.TargetNode, node2))
                            {
                                graph.RemoveEdge(e);
                            }
                        }
                    }
                }
            }

            //replace nodes
            foreach (KeyValuePair<int, Node> m in match.Nodes)
            {
                Node rrNode = rule.RightSide.GetNodeWithRuleID(m.Key);
                string newSymbol;
                if (rrNode != null)
                {
                    newSymbol = rule.RightSide.GetNodeWithRuleID(m.Key).NodeSymbol;
                }
                else
                {
                    continue;
                }

                Node newNode = new Node(graph.GetNewID().ToString());
                newNode.RuleNodeID = m.Key;
                newNode.NodeSymbol = newSymbol;
                graph.AddNode(newNode);
                newNodes.Add(newNode);

                foreach (Edge edge in graph.Edges.ToList().Where(x => Equals(x.TargetNode.Id, m.Value.Id)))
                {
                    graph.AddEdge(edge.SourceNode.Id, edge.SourceNode.NodeSymbol + newNode.NodeSymbol, newNode.Id);
                }
                foreach (Edge edge in graph.Edges.ToList().Where(x => Equals(x.SourceNode.Id, m.Value.Id)))
                {
                    graph.AddEdge(newNode.Id, newNode.NodeSymbol + edge.TargetNode.NodeSymbol, edge.TargetNode.Id);
                }

                graph.RemoveNode(graph.Nodes.FirstOrDefault(x => x.Id == m.Value.Id));
            }

            foreach (Node node in rule.RightSide.Nodes.ToList().Where(x => x.RuleNodeID == -1))
            {
                Node newNode = new Node(graph.GetNewID().ToString());
                newNode.RuleNodeID = -1;
                newNode.NodeSymbol = node.NodeSymbol;
                graph.AddNode(newNode);
            }

            //copy edges
            foreach (Edge e in rule.RightSide.Edges)
            {
                Node n1 = graph.GetNodeWithRuleID(e.SourceNode.RuleNodeID);
                Node n2 = graph.GetNodeWithRuleID(e.TargetNode.RuleNodeID);

                graph.AddEdge(n1.Id, n1.NodeSymbol + n2.NodeSymbol, n2.Id);
            }

            //remove marks
            foreach (Node newNode in newNodes)
            {
                newNode.RuleNodeID = -1;
            }
        }
    }
}
