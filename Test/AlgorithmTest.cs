﻿using System;
using System.Collections.Generic;
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
            Node nn2 = new Node("2");
            g2.AddNode(nn1);
            g2.AddNode(nn2);

            nn1.NodeSymbol = "A";
            nn2.NodeSymbol = "B";
            g2.AddEdge("1", "2");

            Graph g3 = new Graph();
            Node nnn1 = new Node("1");
            Node nnn2 = new Node("2");
            Node nnn3 = new Node("3");
            //Node nnn4 = new Node("4");

            g3.AddNode(nnn1);
            g3.AddNode(nnn2);
            g3.AddNode(nnn3);
            //g3.AddNode(nnn4);

            nnn1.NodeSymbol = "B";
            nnn2.NodeSymbol = "C";
            nnn3.NodeSymbol = "D";
            //nnn4.NodeSymbol = "A";

            g3.AddEdge("1", "2");
            g3.AddEdge("2", "3");
            g3.AddEdge("3", "1");
            //g3.AddEdge("3", "4");


            Rule r = new Rule();
            r.SetRule("xd", g2, g2);

            Algorithm a = new Algorithm();
            bool res = a.CheckSubgraphPresent(r, g);
            List<Match> matches = a.matches;

            Assert.IsTrue(a.CheckSubgraphPresent(r, g));
        }
    }
}
