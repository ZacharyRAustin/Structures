using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class BST<T>
    {
        BSTNode<T> root = null;
        private Func<T, T, bool> comparator;

        public BST() {

        }

        //Note: function f should return true if arg1 > arg2
        public BST(BSTNode<T> r, Func<T, T, bool> f) {
            root = r;
            root.setLevel(0);
            comparator = f;
        }

        public BSTNode<T> BSTInsert(T val) {
            if(root == null)
            {
                root = new BSTNode<T>(val);
                root.setLevel(0);
                return root;
            }

            BSTNode<T> newNode = new BSTNode<T>(val);
            BSTNode<T> parent = findInsertionPoint(val);

            newNode.setParent(parent);
            newNode.setLevel(parent.getLevel() + 1);

            if(compare(val, parent.getValue()))
            {
                parent.setRightChild(newNode);
            }
            else
            {
                parent.setLeftChild(newNode);
            }

            return root;

        }

        private BSTNode<T> findInsertionPoint(T val) {
            BSTNode<T> parent = null;
            BSTNode<T> node = root;

            while(node != null)
            {
                parent = node;
                if(compare(val, node.getValue()))
                {
                    node = node.getRightChild();
                }
                else
                {
                    node = node.getLeftChild();
                }
            }

            return parent;
        }

        public void setComparator(Func<T, T, bool> f) {
            comparator = f;
        }

        private bool compare(T v1, T v2) {
            return comparator(v1, v2);
        }

        public BSTNode<T> search(T val) {
            return BSTSearch(root, val);
        }

        private BSTNode<T> BSTSearch(BSTNode<T> node, T val) {
            if(node == null)
            {
                return null;
            }
            else if(node.getValue().Equals(val))
            {
                return node;
            }
            else if(compare(val, node.getValue()))
            {
                return BSTSearch(node.getRightChild(), val);
            }
            else
            {
                return BSTSearch(node.getLeftChild(), val);
            }
        }

        public BSTNode<T> BSTDelete(T val) {
            BSTNode<T> toDelete = BSTSearch(root, val);
            if(toDelete == null)
            {
                throw new Exception("No node with value" + val.ToString() + " in Tree");
            }
            else if(toDelete.getNumberOfChildren() == 0)
            {
                toDelete.getParent().removeChild(toDelete.getValue());
            }
            else if(toDelete.getNumberOfChildren() == 1)
            {
                BSTNode<T> parent = toDelete.getParent();
                if(parent.getRightChild().getValue().Equals(val))
                {
                    parent.setRightChild(toDelete.getOnlyChild());
                }
                else
                {
                    parent.setLeftChild(toDelete.getOnlyChild());
                }
            }
            else
            {
                BSTNode<T> successor = BSTSuccessor(toDelete);
                BSTDelete(successor.getValue());
                successor.setRightChild(toDelete.getRightChild());
                successor.setLeftChild(toDelete.getLeftChild());
                successor.setParent(toDelete.getParent());
                toDelete.setParent(null);
                toDelete.setLeftChild(null);
                toDelete.setRightChild(null);
            }

            return root;
        }

        public BSTNode<T> BSTSuccessor(BSTNode<T> n) {
            if(n.getRightChild() != null)
            {
                return Min(n.getRightChild());
            }
            else
            {
                BSTNode<T> p = n.getParent();
                BSTNode<T> rc = n;
                //while we aren't at the root
                //and the node is a right child
                while(p != null && n == p.getRightChild())
                {
                    n = p;
                    p = n.getParent();
                }

                return p;
            }
        }

        public BSTNode<T> getMinNode() {
            return Min(root);
        }

        private BSTNode<T> Min(BSTNode<T> n) {
            BSTNode<T> p = n;
            while(p.getLeftChild() != null)
            {
                p = n.getLeftChild();
            }
            return p;
        }

        public void printPostOrder() {
            postOrder(root);
        }

        private void postOrder(BSTNode<T> n) {
            if(n.getLeftChild() != null)
            {
                postOrder(n.getLeftChild());
            }
            if(n.getRightChild() != null)
            {
                postOrder(n.getRightChild());
            }
            Console.WriteLine(n.getValue().ToString());
        }

        public void printPreOrder() {
            preOrder(root);
        }

        private void preOrder(BSTNode<T> n) {
            Console.WriteLine(n.getValue().ToString());
            if(n.getLeftChild() != null)
            {
                preOrder(n.getLeftChild());
            }
            if(n.getRightChild() != null)
            {
                preOrder(n.getRightChild());
            }
        }

        public void printInOrder() {
            inOrder(root);
        }

        private void inOrder(BSTNode<T> n){
            if (n.getLeftChild() != null)
            {
                inOrder(n.getLeftChild());
            }
            Console.WriteLine(n.getValue().ToString());
            if(n.getRightChild() != null)
            {
                inOrder(n.getRightChild());
            }
        }

        public void BFSPrint() {
            Queue<BSTNode<T>> q = new Queue<BSTNode<T>>();
            q.Enqueue(root);

            while(q.Count != 0)
            {
                BSTNode<T> n = q.Dequeue();
                Console.WriteLine(n.getValue().ToString());
                if(n.getLeftChild() != null)
                {
                    q.Enqueue(n.getLeftChild());
                }
                if(n.getRightChild() != null)
                {
                    q.Enqueue(n.getRightChild());
                }
            }
        }

        public void BFSPrintWithLevels() {
            Queue<BSTNode<T>> q = new Queue<BSTNode<T>>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                BSTNode<T> n = q.Dequeue();
                Console.WriteLine(n.getValue().ToString() + " at level " + n.getLevel());
                if (n.getLeftChild() != null)
                {
                    q.Enqueue(n.getLeftChild());
                }
                if (n.getRightChild() != null)
                {
                    q.Enqueue(n.getRightChild());
                }
            }
        }

        public void BFSPrintRecur() {
            BFSPrintRecur(root);
        }

        private void BFSPrintRecur(BSTNode<T> n) {
            Console.WriteLine(n.getValue().ToString());
            if(n.getLeftChild()!= null)
            {
                BFSPrintRecur(n.getLeftChild());
            }
            if(n.getRightChild() != null)
            {
                BFSPrintRecur(n.getRightChild());
            }
        }

        public void BFSNodeOp(Action<BSTNode<T>> f){
            Queue<BSTNode<T>> q = new Queue<BSTNode<T>>();
            q.Enqueue(root);
            while(q.Count != 0){
                BSTNode<T> n = q.Dequeue();
                f(n);
                if(n.getLeftChild() != null)
                {
                    q.Enqueue(n.getLeftChild());
                }
                if(n.getRightChild() != null)
                {
                    q.Enqueue(n.getRightChild());
                }
            }
        }

        public Object BFSReturningNodeOp(Func<BSTNode<T>, Object> f) {
            Queue<BSTNode<T>> q = new Queue<BSTNode<T>>();
            q.Enqueue(root);
            while(q.Count != 0)
            {
                BSTNode<T> n = q.Dequeue();
                Object o = f(n);
                if(o != null)
                {
                    return o;
                }

                if (n.getLeftChild() != null)
                {
                    q.Enqueue(n.getLeftChild());
                }

                if (n.getRightChild() != null)
                {
                    q.Enqueue(n.getRightChild());
                }
            }

            return null;
        }
    }

}
