using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Msagl.Drawing;
using NecrodancerLevelGenerator;

namespace NecrodancerGenerator
{
    public class Generator
    {
        private Dictionary<string, List<Room>> _symbolToRooms = new Dictionary<string, List<Room>>();
        private Dictionary<Node, Room> _nodeToRoom = new Dictionary<Node, Room>();
        private Graph _missionGraph;
        private List<Room> _rooms = new List<Room>();
        private IntVector2 _currentPosition;
        private int _roomOffset;
        private Grid _grid;
        private Random r;


        public Generator(List<Room> rooms, Graph missionGraph)
        {
            _rooms = rooms;
            _missionGraph = missionGraph;

            foreach (Room room in rooms)
            {
                string name = Regex.Replace(room.Name, @"[\d-]", string.Empty);

                if (!_symbolToRooms.ContainsKey(name))
                {
                    _symbolToRooms.Add(name, new List<Room>());
                }
                if (!_symbolToRooms[name].Contains(room))
                {
                    _symbolToRooms[name].Add(room);
                }
            }

            int cellSize = rooms
                .OrderByDescending(r => r.GetMaxDimension())
                .FirstOrDefault()
                .GetMaxDimension();
            
            _grid = new Grid(10
                , cellSize);

            r = new Random();
        }

        //BFS
        public void GenerateRoomLayout()
        {
            List<Node> queue = new List<Node>();

            Node startNode = _missionGraph.Nodes.FirstOrDefault(n => n.NodeSymbol == "start");

            if (startNode == null || !_symbolToRooms.ContainsKey("start"))
            {
                return;
            }

            Room startRoom = _symbolToRooms["start"][0];
            _nodeToRoom.Add(startNode, startRoom);
            _grid.AppendStartRoom(startRoom);

            queue.Add(startNode);

            while (queue.Count > 0)
            {
                Node parentNode = queue.Last();
                Room parentRoom = _nodeToRoom[parentNode];

                Console.WriteLine("Parent node: " + parentNode.NodeSymbol);

                int childrenCount = parentNode.OutEdges.Count();
                int neighboursCount = _grid.GetEmptyNeighbourCount(_grid.GetRoomPos(parentRoom));

                if (childrenCount > neighboursCount)
                {
                    Node tempNode = new Node(_missionGraph.GetNewID().ToString());
                    tempNode.NodeSymbol = "temp";
                    _missionGraph.AddNode(tempNode);

                    List<Edge> spareEdges = parentNode
                        .OutEdges
                        .ToList();

                    spareEdges = spareEdges
                        .Skip(neighboursCount - 1)
                        .Take(spareEdges.Count - (neighboursCount -1))
                        .ToList();

                    foreach (Edge edge in spareEdges)
                    {
                        _missionGraph.AddEdge(tempNode.Id, edge.Target);
                        _missionGraph.RemoveEdge(edge);
                    }

                    _missionGraph.AddEdge(parentNode.Id, tempNode.Id);
                }

                foreach (Edge edge in parentNode.OutEdges)
                {
                    //child node is a child of n
                    Node childNode = edge.TargetNode;
                    Room childRoom = Utils.DeepClone(
                        _symbolToRooms[childNode.NodeSymbol][r.Next(0, _symbolToRooms[childNode.NodeSymbol].Count)]);
                    _nodeToRoom.Add(childNode, childRoom);
                    _grid.AppendNewRoom(parentRoom, childRoom);

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