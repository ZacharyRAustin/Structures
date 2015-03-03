using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndirectedGraph
{
    class GraphNode<T>
    {
        private List<GraphNode<T>> neighbors = new List<GraphNode<T>>();
        private Dictionary<GraphNode<T>, int> distance = new Dictionary<GraphNode<T>, int>();
        private T value;
        
        public GraphNode(T val) {
            value = val;
        }

        public void addNeighbor(GraphNode<T> n) {
            if(!neighbors.Contains(n))
            {
                neighbors.Add(n);
            }
        }

        public void addNeighbor(GraphNode<T> n, int d) {
            if(!neighbors.Contains(n))
            {
                neighbors.Add(n);
            }
            distance.Add(n, d);
        }

        public int getNeighborCount() {
            return neighbors.Count;
        }

        public int getDistance(GraphNode<T> to) {
            if(distance.ContainsKey(to))
            {
                return distance[to];
            }
            else
            {
                return -1;
            }
        }


        public GraphNode<T> getNeighbor(int i) {
            return neighbors[i];
        }

        public T getValue() {
            return value;
        }
    }
}
