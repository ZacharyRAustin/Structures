using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BST;
using UndirectedGraph;

namespace Trees
{
    class Program
    {
        static void Main(string[] args) {
            GraphNode<int> nodeA = new GraphNode<int>(1);
            GraphNode<int> nodeB = new GraphNode<int>(2);
            GraphNode<int> nodeC = new GraphNode<int>(3);

            UndirectedGraph<int> g = new UndirectedGraph<int>();
            g.insertNode(nodeA);
            g.insertNode(nodeB);

            nodeC.addNeighbor(nodeA);
            nodeC.addNeighbor(nodeB, 14);
            g.insertNode(nodeC);

            g.printNodeNeighbors();

            Console.ReadLine();
        }
    }
}
