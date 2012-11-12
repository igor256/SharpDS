using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpDS.ds.abs;

namespace SharpDS.ds.abs
{
    /// <summary>
    /// Definition of a rootclass for heap nodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class HeapNode<T>:Node<T>
    {
        protected HeapNode<T> _parent; // reference to the parent node
        protected HeapNode<T> _left;   // ref. to leftchild
        protected HeapNode<T> _right;  // ref. to rightchild

        protected int price;          // price of the node

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value">value contained in the node</param>
        /// <param name="price">price of the node</param>
        public HeapNode(ref T value, int price)
        {
            setValue(ref value);
            setPrice(price);
        }

        /// <summary>
        /// Returns a reference to parent node
        /// </summary>
        public HeapNode<T> getParent()
        {
            return _parent;
        }

        /// <summary>
        /// Sets a reference to a parent.
        /// </summary>
        /// <param name="value"></param>
        public void setParent(ref HeapNode<T> value)
        {
            this._parent = value;
        }

        /// <summary>
        /// Returns a reference to a left child node
        /// </summary>
        public HeapNode<T> getLeft()
        {
            return _left;
        }

        /// <summary>
        /// Sets the left node reference
        /// </summary>
        /// <param name="value"></param>
        public void setLeft(ref HeapNode<T> value)
        {
            this._left = value;
        }

        /// <summary>
        /// Returns a reference to a right child node
        /// </summary>
        public HeapNode<T> getRight()
        {
            return _right;
        }

        /// <summary>
        /// Sets the right node reference
        /// </summary>
        /// <param name="value"></param>
        public void setRight(ref HeapNode<T> value)
        {
            this._right = value;
        }

        /// <summary>
        /// Sets the price of the node to value
        /// </summary>
        /// <param name="value"></param>
        public void setPrice(int value)
        {
            price = value;
        }

        /// <summary>
        /// Returns the price for the node
        /// </summary>
        /// <returns></returns>
        public int getPrice()
        {
            return price;
        }

    }
}
