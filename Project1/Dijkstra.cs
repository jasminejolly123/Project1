using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace Project1
{
    internal class Dijkstra : Movement
    {
        private List <Microsoft.Xna.Framework.Vector2> _nodes;
        private List<Rectangle> _walls;

        public Pacman Target { get; set; }
        var Start = new Microsoft.Xna.Framework.Vector2(760, 60);
        var End = Target.Position;

        public void nodes()
        {
            _nodes = new List<Microsoft.Xna.Framework.Vector2>();
            for (int i = 0; i < 800; i+=20)
            {
                for (int j = 0; j < 400; j+=20)
                {
                    foreach (Rectangle rectangle in _walls)
                    {
                        if (rectangle.Contains(new Microsoft.Xna.Framework.Vector2( i, j)))
                        {
                        }
                        else
                        {
                            _nodes.Add(new Microsoft.Xna.Framework.Vector2(i, j));
                        }
                    }   
                } 
            }
        }

        public void Walls()
        {
            _walls = new List<Rectangle>();
            _walls.Add(new Rectangle(0, 80, 80, 40));
            _walls.Add(new Rectangle(0, 400, 80, 80));
            _walls.Add(new Rectangle(164, 0, 40, 112));
            _walls.Add(new Rectangle(164, 112, 144, 40));
            _walls.Add(new Rectangle(352, 0, 40, 280));
            _walls.Add(new Rectangle(598, 0, 40, 160));
            _walls.Add(new Rectangle(486, 120, 112, 40));
            _walls.Add(new Rectangle(176, 400, 20, 80));
            _walls.Add(new Rectangle(196, 400, 80, 20));
            _walls.Add(new Rectangle(256, 320, 20, 80));
            _walls.Add(new Rectangle(276, 320, 60, 20));
            _walls.Add(new Rectangle(296, 450, 80, 30));
            //Wall13 = new Rectangle(296, 420, 40, 20);
            _walls.Add(new Rectangle(416, 400, 40, 80));
            _walls.Add(new Rectangle(456, 440, 136, 40));
            _walls.Add(new Rectangle(552, 400, 40, 80));
            _walls.Add(new Rectangle(477, 320, 64, 40));
            _walls.Add(new Rectangle(656, 304, 144, 40));
            _walls.Add(new Rectangle(760, 344, 40, 140));
            _walls.Add(new Rectangle(88, 184, 40, 148));
            _walls.Add(new Rectangle(192, 208, 96, 60));
            _walls.Add(new Rectangle(432, 36, 120, 40));
            _walls.Add(new Rectangle(432, 224, 240, 40));
            _walls.Add(new Rectangle(648, 384, 60, 52));
        }

        public List<Microsoft.Xna.Framework.Vector2> GetShortestPathDijkstra()
        {
            DijkstraSearch();
            var shortestPath = new List<Microsoft.Xna.Framework.Vector2>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End);
            shortestPath.Reverse();
            return shortestPath;
        }



        private void BuildShortestPath(List<Microsoft.Xna.Framework.Vector2> list, Microsoft.Xna.Framework.Vector2 node)
        {
            if (new Microsoft.Xna.Framework.Vector2(760, 60) == null)
                return;
            list.Add(new Microsoft.Xna.Framework.Vector2(760, 60));
            BuildShortestPath(list, new Microsoft.Xna.Framework.Vector2(760, 60));
        }

        private void DijkstraSearch()
        {
            Start.MinCostToStart = 0;
            var prioQueue = new List<var>();
            prioQueue.Add(Start);
            do
            {
                prioQueue = prioQueue.OrderBy(x => x.MinCostToStart).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (var cnn in node.Connections.OrderBy(x => x.Cost))
                {
                    var childNode = cnn.ConnectedNode;
                    if (childNode.Visited)
                        continue;
                    if (childNode.MinCostToStart == null ||
                        node.MinCostToStart + cnn.Cost < childNode.MinCostToStart)
                    {
                        childNode.MinCostToStart = node.MinCostToStart + cnn.Cost;
                        childNode.NearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                            prioQueue.Add(childNode);
                    }
                }
                node.Visited = true;
                if (node == End)
                    return;
            } while (prioQueue.Any());
        }
    }
}
