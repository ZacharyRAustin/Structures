using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndirectedGraph
{
    class UndirectedGraph<T>
    {
        private List<GraphNode<T>> nodes = new List<GraphNode<T>>();
        private Dictionary<GraphNode<T>, int> visited = new Dictionary<GraphNode<T>, int>();
        private int visitCount = 0;

        public UndirectedGraph() {

        }

        public void insertNode(GraphNode<T> n) {
            nodes.Add(n);
            visited.Add(n, visitCount);
            updateNeighborsOfNode(n);
        }

        private void updateNeighborsOfNode(GraphNode<T> n) {
            for(int i = 0; i < n.getNeighborCount(); i++)
            {
                GraphNode<T> temp = n.getNeighbor(i);
                if(n.getDistance(temp) > 0)
                {
                    temp.addNeighbor(n, n.getDistance(temp));
                }
                else
                {
                    temp.addNeighbor(n);
                }
            }
        }



        public void printNodeNeighbors() {
            for(int i = 0; i < nodes.Count; i++)
            {
                GraphNode<T> temp = nodes[i];
                Console.WriteLine("Printing Node " + temp.getValue().ToString());
                for(int j = 0; j < temp.getNeighborCount(); j++)
                {
                    Console.WriteLine("Neighbor " + temp.getNeighbor(j).getValue().ToString() + " with distance " 
                        + temp.getDistance(temp.getNeighbor(j)));
                }

                Console.WriteLine("\n");
            }
        }

        public void DFS() {
            visitCount++;
            for(int i = 0; i < nodes.Count; i++)
            {
                if(visited[nodes[i]] != visitCount)
                {
                    DFSVisit(nodes[i]);
                }
            }
        }

        private void DFSVisit(GraphNode<T> n) {
            visited[n] = visitCount;
            for(int i = 0; i < n.getNeighborCount(); i++)
            {
                if(visited[n.getNeighbor(i)] != visitCount)
                {
                    DFSVisit(n.getNeighbor(i));
                }
            }
        }
    }
}
