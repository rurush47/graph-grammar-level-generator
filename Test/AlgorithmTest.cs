using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LevelGenerator;
using Microsoft.Msagl.Drawing;

namespace Test
{
    [TestClass]
    public class AlgorithmTest
    {
        [TestMethod]
        public void TestSubgraphPresent()
        {
            Graph g = new Graph();
            Node n1 = new Node("1");
            Node n2 = new Node("2");
            Node n3 = new Node("3");
            Node n4 = new Node("4");
            Node n5 = new Node("5");
            Node n6 = new Node("6");
            Node n7 = new Node("7");
            Node n8 = new Node("8");
            g.AddNode(n1);
            g.AddNode(n2);
            g.AddNode(n3);
            g.AddNode(n4);
            g.AddNode(n5);
            g.AddNode(n6);
            g.AddNode(n7);
            g.AddNode(n8);

            n1.NodeSymbol = "A";
            n2.NodeSymbol = "B";
            n3.NodeSymbol = "C";
            n4.NodeSymbol = "D";
            n5.NodeSymbol = "A";
            n6.NodeSymbol = "B";
            n7.NodeSymbol = "C";
            n8.NodeSymbol = "D";

            g.AddEdge("1", "AB", "2");
            g.AddEdge("2", "BC", "3");
            g.AddEdge("3", "CD", "4");
            g.AddEdge("4", "DB", "2");
            g.AddEdge("4", "DA", "5");
            g.AddEdge("5", "AB2", "6");
            g.AddEdge("6", "BC2", "7");
            g.AddEdge("7", "CD2", "8");
            g.AddEdge("8", "DB2", "6");


            Graph g2 = new Graph();
            Node nn1 = new Node("1");
            nn1.RuleNodeID = 1;
            Node nn2 = new Node("2");
            nn2.RuleNodeID = 2;

            g2.AddNode(nn1);
            g2.AddNode(nn2);

            nn1.NodeSymbol = "A";
            nn2.NodeSymbol = "B";
            g2.AddEdge("1", "2");

            Graph g3 = new Graph();
            Node nnn1 = new Node("1");
            nnn1.RuleNodeID = 1;
            Node nnn2 = new Node("2");
            nnn2.RuleNodeID = 2;
            Node nnn3 = new Node("3");
            nnn3.RuleNodeID = 3;

            g3.AddNode(nnn1);
            g3.AddNode(nnn2);
            g3.AddNode(nnn3);

            nnn1.NodeSymbol = "B";
            nnn2.NodeSymbol = "C";
            nnn3.NodeSymbol = "D";

            g3.AddEdge("1", "2");
            g3.AddEdge("2", "3");
            g3.AddEdge("3", "1");

            Rule r = new Rule();
            r.SetRule("xd", g2, g2);

            Rule r2 = new Rule();
            r2.SetRule("xd2", g3, g3);

            Matcher a = new Matcher();

            Assert.IsTrue(a.CheckSubgraphPresent(r, g));
            Assert.AreEqual(a.Matches.Count, 2);

            a = new Matcher();

            Assert.IsTrue(a.CheckSubgraphPresent(r2, g));
            Assert.AreEqual(a.Matches.Count, 2);
        }

        [TestMethod]
        public void TestReplaceNodes()
        {
            Graph g = new Graph();
            Node n1 = new Node(g.GetNewID().ToString());
            Node n2 = new Node(g.GetNewID().ToString());
            Node n3 = new Node(g.GetNewID().ToString());
            Node n4 = new Node(g.GetNewID().ToString());
            Node n5 = new Node(g.GetNewID().ToString());
            Node n6 = new Node(g.GetNewID().ToString());
            Node n7 = new Node(g.GetNewID().ToString());
            Node n8 = new Node(g.GetNewID().ToString());
            g.AddNode(n1);
            g.AddNode(n2);
            g.AddNode(n3);
            g.AddNode(n4);
            g.AddNode(n5);
            g.AddNode(n6);
            g.AddNode(n7);
            g.AddNode(n8);

            n1.NodeSymbol = "A";
            n2.NodeSymbol = "B";
            n3.NodeSymbol = "C";
            n4.NodeSymbol = "D";
            n5.NodeSymbol = "A";
            n6.NodeSymbol = "B";
            n7.NodeSymbol = "C";
            n8.NodeSymbol = "D";

            g.AddEdge("1", "AB", "2");
            g.AddEdge("2", "BC", "3");
            g.AddEdge("3", "CD", "4");
            g.AddEdge("4", "DB", "2");
            g.AddEdge("4", "DA", "5");
            g.AddEdge("5", "AB2", "6");
            g.AddEdge("6", "BC2", "7");
            g.AddEdge("7", "CD2", "8");
            g.AddEdge("8", "DB2", "6");

            //rule left
            Graph rl = new Graph();
            Node rl1 = new Node(rl.GetNewID().ToString());
            rl1.RuleNodeID = 1;
            rl1.NodeSymbol = "A";
            Node rl2 = new Node(rl.GetNewID().ToString());
            rl2.RuleNodeID = 2;
            rl2.NodeSymbol = "B";

            rl.AddNode(rl1);
            rl.AddNode(rl2);

            rl.AddEdge("1", "2");

            //rule right
            Graph rr = new Graph();
            Node rr1 = new Node(rr.GetNewID().ToString());
            rr1.RuleNodeID = 1;
            rr1.NodeSymbol = "G";
            Node rr2 = new Node(rr.GetNewID().ToString());
            rr2.RuleNodeID = 2;
            rr2.NodeSymbol = "H";

            rr.AddNode(rr1);
            rr.AddNode(rr2);

            rr.AddEdge("1", "2");

            //rule
            Rule r = new Rule();
            r.SetRule("test rule", rl, rr);

            Matcher m = new Matcher();
            m.CheckSubgraphPresent(r, g);

            Assert.AreEqual(m.Matches.Count, 2);

            Match match = m.Matches[1];

            Replacer.ReplaceNodesWithARule(g, r, match);

            Assert.AreEqual(g.Edges.ToList().Exists(x => x.SourceNode.NodeSymbol == "G" && x.TargetNode.NodeSymbol == "H"), true);
            Assert.AreEqual(g.Edges.ToList().Exists(x => x.SourceNode.NodeSymbol == "D" && x.TargetNode.NodeSymbol == "H"), true);
            Assert.AreEqual(g.Edges.ToList().Exists(x => x.SourceNode.NodeSymbol == "D" && x.TargetNode.NodeSymbol == "G"), true);
            Assert.AreEqual(g.Edges.ToList().Exists(x => x.SourceNode.NodeSymbol == "H" && x.TargetNode.NodeSymbol == "C"), true);
        }
    }
}
