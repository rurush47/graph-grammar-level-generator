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
        private Graph _missionGraph;
        private List<Room> _rooms = new List<Room>();
        private List<Room> _roomsToSpawn = new List<Room>();
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

            _grid = new Grid(100);
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
            startRoom.Position = new IntVector2(0, 0);
            _grid.AppendStartRoom(startRoom.Position, startRoom);

            _roomsToSpawn.Add(startRoom);
            queue.Add(startNode);

            while (queue.Count > 0)
            {
                Node n = queue.Last();
                Room parentRoom = _symbolToRoom[n.NodeSymbol];

                Console.WriteLine("Parent node: " + n.NodeSymbol);
                foreach (Edge edge in n.OutEdges)
                {
                    //child node is a child of n
                    Node childNode = edge.TargetNode;
                    Room childRoom = ObjectCopier.Clone(_symbolToRoom[childNode.NodeSymbol]);
                    _grid.AppendNewRoom(parentRoom.Position, childRoom);

                    queue.Insert(0, childNode);
                    Console.WriteLine(childNode.NodeSymbol + " Parent: " + n.NodeSymbol);
                }
                Console.WriteLine("");

                queue.Remove(queue.Last());
            }
        }
    }
}