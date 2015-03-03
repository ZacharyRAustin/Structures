using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class BSTNode<T>
    {
        private BSTNode<T> left;
        private BSTNode<T> right;
        private BSTNode<T> parent;
        private T value;

        public BSTNode(T val) {
            value = val;
        }

        public BSTNode<T> getLeftChild() {
            return left;
        }

        public BSTNode<T> getRightChild() {
            return right;
        }

        public BSTNode<T> getParent() {
            return parent;
        }

        public T getValue() {
            return value;
        }

        public bool isRoot() {
            if (parent == null)
            {
                return true;
            }
            return false;
        }

        public void setValue(T val) {
            value = val;
        }

        public void setParent(BSTNode<T> p) {
            parent = p;
        }

        public void setRightChild(BSTNode<T> rc) {
            right = rc;
        }

        public void setLeftChild(BSTNode<T> lc) {
            left = lc;
        }

        public int getNumberOfChildren() {
            if(left != null && right != null)
            {
                return 2;
            }
            else if(left != null || right != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void removeChild(T val) {
            if(right != null && right.getValue().Equals(val))
            {
                right = null;
            }
            else if(left != null && left.getValue().Equals(val))
            {
                left = null;
            }
            else if(left == null && right == null)
            {
                throw new Exception("Can't remove child when both children are null");
            }
            else
            {
                throw new Exception("Node does not have a child with value " + val.ToString());
            }
        }

        public BSTNode<T> getOnlyChild() {
            if(getNumberOfChildren() != 1)
            {
                throw new Exception("There isn't only 1 child!");
            }
            else if(left != null)
            {
                return left;
            }
            else
            {
                return right;
            }
        }

    }
}
