using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpDS.ds.abs;

namespace SharpDS.ds.binaryheap
{
    /// <summary>
    /// Definition of a rootclass for heap nodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T>:Node<T>
    {
        protected BinaryTreeNode<T> _parent; // reference to the parent node
        protected BinaryTreeNode<T> _left;   // ref. to leftchild
        protected BinaryTreeNode<T> _right;  // ref. to rightchild

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value">value contained in the node</param>
        /// <param name="price">price of the node</param>
        public BinaryTreeNode(ref T value, int price)
        {
            setValue(ref value);
            setPrice(price);
        }

        /// <summary>
        /// Returns a reference to parent node
        /// </summary>
        public BinaryTreeNode<T> getParent()
        {
            return _parent;
        }

        /// <summary>
        /// Sets a reference to a parent.
        /// </summary>
        /// <param name="value"></param>
        public void setParent(ref BinaryTreeNode<T> value)
        {
            this._parent = value;
        }

        /// <summary>
        /// Returns a reference to a left child node
        /// </summary>
        public BinaryTreeNode<T> getLeft()
        {
            return _left;
        }

        /// <summary>
        /// Sets the left node reference
        /// </summary>
        /// <param name="value"></param>
        public void setLeft(ref BinaryTreeNode<T> value)
        {
            this._left = value;
        }

        /// <summary>
        /// Returns a reference to a right child node
        /// </summary>
        public BinaryTreeNode<T> getRight()
        {
            return _right;
        }

        /// <summary>
        /// Sets the right node reference
        /// </summary>
        /// <param name="value"></param>
        public void setRight(ref BinaryTreeNode<T> value)
        {
            this._right = value;
        }
		
		public static bool operator <(BinaryTreeNode<T> left, BinaryTreeNode<T> right)
		{
			if(left.getPrice() < right.getPrice())
				return true;
			return false;
		}
		
		public static bool operator >(BinaryTreeNode<T> left, BinaryTreeNode<T> right)
		{
			if(left.getPrice() > right.getPrice())
				return true;
			return false;
		}

    }
}

