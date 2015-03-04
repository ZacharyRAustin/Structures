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

            BST<int> tree = new BST<int>();
            tree.setComparator(compareInts);

            tree.BSTInsert(5);
            tree.BSTInsert(3);
            tree.BSTInsert(8);
            tree.BSTInsert(7);
            tree.BSTInsert(9);
            tree.BSTInsert(2);
            tree.BSTInsert(4);

            tree.BFSPrintWithLevels();
            Console.WriteLine();
            BSTNode<int> n = (BSTNode<int>)tree.BFSReturningNodeOp(increaseAndFind);
            Console.WriteLine(n.getValue() + " with children " + n.getLeftChild().getValue()
                + " and " + n.getRightChild().getValue());
            Console.WriteLine();
            tree.BFSNodeOp(printNode);
            Console.ReadLine();
        }

        public static bool compareInts(int a, int b) {
            return a > b;
        }

        public static void printNode(BSTNode<int> n) {
            Console.WriteLine(n.getValue().ToString() + " at level " + n.getLevel());
        }

        public static BSTNode<int> increaseAndFind(BSTNode<int> n) {
            if(n.getValue() == 8)
            {
                return n;
            }
            else
            {
                n.setValue(n.getValue() + 1);
                return null;
            }
        }
    }
}
