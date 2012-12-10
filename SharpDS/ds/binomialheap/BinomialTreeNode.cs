using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpDS.ds.abs;

namespace SharpDS.ds.binomialheap
{
    /// <summary>
    /// Provides a simple node to use with 
    /// binomial heaps
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinomialTreeNode<T>:Node<T>
    {
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
        private void setParent(BinomialTreeNode<T> value)
        {
            this._parent = value;
        }

      


        /// <summary>
        /// Adds a child tree to the node
        /// </summary>
        /// <param name="root"></param>
        public void addChildTree(BinomialTreeNode<T> node) 
        {
			node.setParent(this);
            children.Add(node);
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
