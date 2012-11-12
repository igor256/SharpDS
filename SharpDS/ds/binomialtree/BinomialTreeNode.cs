using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpDS.ds.abs;

namespace SharpDS.ds.binomialtree
{
    /// <summary>
    /// Provides a simple node to use with 
    /// binomial heaps
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BinomialTreeNode<T>:Node<T>
    {
        private int _price = 0;
        private BinomialTreeNode<T> _parent;
        private List <BinomialTreeNode<T>> children;
        
        public BinomialTreeNode(ref T value, int price)
        {
            children = new List<BinomialTreeNode<T>>();
            setValue(ref value);
            setPrice(price);
        }

        /// <summary>
        /// Returns a reference to parent node
        /// </summary>
        public BinomialTreeNode<T> getParent()
        {
            return _parent;
        }

        /// <summary>
        /// Sets a reference to a parent.
        /// </summary>
        /// <param name="value"></param>
        public void setParent(ref BinomialTreeNode<T> value)
        {
            this._parent = value;
        }

        /// <summary>
        /// Sets the price of the node to value
        /// </summary>
        /// <param name="value"></param>
        public void setPrice(int value)
        {
           _price = value;
        }

        /// <summary>
        /// Returns the price for the node
        /// </summary>
        /// <returns></returns>
        public int getPrice()
        {
            return _price;
        }


        /// <summary>
        /// Adds a child tree to the node
        /// </summary>
        /// <param name="root"></param>
        public void addChildTree(BinomialTreeNode<T> root) 
        {
            children.Add(root);
        }

        /// <summary>
        /// Returns the children of node
        /// </summary>
        /// <returns></returns>
        public List<BinomialTreeNode<T>> getChildren() 
        {
            return children;
        }
    }
}
