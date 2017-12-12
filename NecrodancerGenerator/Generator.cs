using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using Microsoft.Msagl.Drawing;
using NecrodancerLevelGenerator;

namespace NecrodancerGenerator
{
    public class Generator
    {
        private Dictionary<string, Room> _symbolToRoom = new Dictionary<string, Room>();
        private Dictionary<Node, Room> _nodeToRoom = new Dictionary<Node, Room>();
        private Graph _missionGraph;
        private List<Room> _rooms = new List<Room>();
        private IntVector2 _currentPosition;
        private int _roomOffset;
        private Grid _grid;

        public Generator(List<Room> rooms, Graph missionGraph)
        {
            _rooms = rooms;
            _missionGraph = missionGraph;

            foreach (Node node in _missionGraph.Nodes)
            {
                if (!_symbolToRoom.ContainsKey(node.NodeSymbol))
                {
                    Room room = _rooms.FirstOrDefault(r => r.Name == node.NodeSymbol);
                    if (room != null)
                    {
                        _symbolToRoom.Add(node.NodeSymbol, room);
                    }
                }
            }

            int cellSize = rooms
                .OrderByDescending(r => r.GetMaxDimension())
                .FirstOrDefault()
                .GetMaxDimension();
            
            _grid = new Grid(5, cellSize);
        }

        //BFS
        public void GenerateRoomLayout()
        {
            List<Node> queue = new List<Node>();

            Node startNode = _missionGraph.Nodes.FirstOrDefault(n => n.NodeSymbol == "start");

            if (startNode == null || !_symbolToRoom.ContainsKey("start"))
            {
                return;
            }

            Room startRoom = _symbolToRoom["start"];
            _nodeToRoom.Add(startNode, startRoom);
            _grid.AppendStartRoom(startRoom);

            queue.Add(startNode);

            while (queue.Count > 0)
            {
                Node parentNode = queue.Last();

                Console.WriteLine("Parent node: " + parentNode.NodeSymbol);
                foreach (Edge edge in parentNode.OutEdges)
                {
                    //child node is a child of n
                    Node childNode = edge.TargetNode;
                    Room childRoom = Utils.DeepClone(_symbolToRoom[childNode.NodeSymbol]);
                    _nodeToRoom.Add(childNode, childRoom);
                    _grid.AppendNewRoom(_nodeToRoom[parentNode], childRoom);

                    queue.Insert(0, childNode);
                    Console.WriteLine(childNode.NodeSymbol + " Parent: " + parentNode.NodeSymbol);
                }
                Console.WriteLine("");

                queue.Remove(queue.Last());
            }
        }

        public Grid GetGrid()
        {
            return _grid;
        }
    }
}