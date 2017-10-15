﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Msagl.Drawing;

namespace LevelGenerator
{
    public class Algorithm
    {
        public List<string> nodesIDs = new List<string>();
        public List<string> edgeIDs = new List<string>();
        public List<Match> matches = new List<Match>();

        public bool CheckSubgraphPresent(Rule rule, Graph graph)
        {
            bool compareReturnValue = false;

            foreach (Node node in graph.Nodes.ToList())
            {
                if (node.NodeSymbol == rule.LeftSide.Nodes.ToArray()[0].NodeSymbol)
                {
                    if (Compare(rule.LeftSide.Nodes.ToArray()[0], node, rule.LeftSide, new List<Edge>()))
                    {
                        //Console.WriteLine("Compare returned true");
                        compareReturnValue = true;
                        Match newMatch = new Match();
                        newMatch.edgeIDs = edgeIDs;
                        newMatch.nodeIDs = nodesIDs;
                        edgeIDs = new List<string>();
                        nodesIDs = new List<string>();
                        matches.Add(newMatch);
                        //break;
                    }
                    else
                    {
                        //Console.WriteLine("Compare returned false");
                    }
                }
            }

            return compareReturnValue;
        }

        bool Compare(Node ruleNode, Node mainNode, Graph ruleLeft, List<Edge> visitedEdges)
        {
            if (ruleNode.NodeSymbol != mainNode.NodeSymbol)
                return false;
            else
            {
                nodesIDs.Add(mainNode.Id);
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
                        //todo: would it be better to store pointers to Nodes instead of uids? wouldn't need to pass graph in
                        if (/*ruleEdge.TightCoupling == mainEdge.TightCoupling && */
                            Compare(ruleEdge.TargetNode, mainEdge.TargetNode, ruleLeft, visitedEdges))
                        {
                            edgeIDs.Add(mainEdge.LabelText);
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
}
