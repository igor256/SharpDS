using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDS.ds.abs;

namespace SharpDS.ds.binaryheap
{
    /// <summary>
    /// Provides a simple node for 
    /// use with binary heaps
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BinaryTreeNode<T>:Node<T>
    {
        private BinaryTreeNode<T>  _parent; // reference to the parent node
        private BinaryTreeNode<T> _left;    // ref. to leftchild
        private BinaryTreeNode<T> _right;   // ref. to rightchild
        private uint price;                 // price of the node

        public BinaryTreeNode(ref T value, uint price)
        {
            setValue(ref value); // sets the value to reference - hope this is ok
            setPrice(price);     // prices the node
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

        /// <summary>
        /// Sets the price of the node to value
        /// </summary>
        /// <param name="value"></param>
        public void setPrice(uint value) 
        {
            price = value;
        }

        /// <summary>
        /// Returns the price for the node
        /// </summary>
        /// <returns></returns>
        public uint getPrice() 
        {
            return price;
        }
    }
}
