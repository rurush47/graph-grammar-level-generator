using System;
using System.Collections.Generic;
using Microsoft.Msagl.Drawing;

namespace LevelGenerator
{
    [Serializable]
    public class SerializedGraph
    {
        public SerializedGraph()
        {
            
        }

        public List<SerializedNode> SerializedNodes = new List<SerializedNode>();
        public List<SerializedEdge> SerializedEdges = new List<SerializedEdge>();
        public int CurrentID;

        public class SerializedNode
        {
            public string NodeID;
            public string NodeSymbol;
            public int RuleID;
        }

        public class SerializedEdge
        {
            public string SourceID;
            public string TargetID;
        }

        public void Serialize(Graph graph)
        {
            CurrentID = graph.IDs;

            foreach (Node n in graph.Nodes)
            {
                SerializedNode serializedNode = new SerializedNode();
                serializedNode.NodeID = n.Id;
                serializedNode.NodeSymbol = n.NodeSymbol;
                serializedNode.RuleID = n.RuleNodeID;

                SerializedNodes.Add(serializedNode);
            }

            foreach (Edge graphEdge in graph.Edges)
            {
                SerializedEdge serializedEdge = new SerializedEdge();
                serializedEdge.SourceID = graphEdge.SourceNode.Id;
                serializedEdge.TargetID = graphEdge.TargetNode.Id;

                SerializedEdges.Add(serializedEdge);
            }
        }

        public Graph Deserialize()
        {
            Graph g = new Graph();

            g.IDs = CurrentID;

            foreach (SerializedNode serializedNode in SerializedNodes)
            {
                Node n = new Node(serializedNode.NodeID);
                n.NodeSymbol = serializedNode.NodeSymbol;
                n.RuleNodeID = serializedNode.RuleID;
                n.LabelText = n.RuleNodeID == -1 ? n.NodeSymbol : n.RuleNodeID + ":" + n.NodeSymbol;
                g.AddNode(n);
            }

            foreach (SerializedEdge serializedEdge in SerializedEdges)
            {
                g.AddEdge(serializedEdge.SourceID, "", serializedEdge.TargetID);
            }

            return g;
        }
    }
}
