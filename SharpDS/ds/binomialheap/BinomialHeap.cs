using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpDS.ds.abs;
using SharpDS.ds.binaryheap;
using SharpDS.ds.binomialtree;

namespace SharpDS.ds.binomialheap
{
    /// <summary>
    /// SharpDS implementation of binomial heap.
    /// 
    /// For fast merge operations and fun :D 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BinomialHeap<T>:SharpDS<T>
    {
        private List<BinomialTreeNode<T>> rootNodes; // contains an array of root nodes of trees in the heap. BinaryHeap used for prioritising

        /// <summary>
        /// Default constructor for the binomial heap
        /// </summary>
        public BinomialHeap()
        {
            rootNodes = new List<BinomialTreeNode<T>>();
            rootNodes.Add(null); // prepare null at first index (improve);
        }

        /// <summary>
        /// Creates a new zero binomial heap
        /// </summary>
        /// <param name="rootnode"></param>
        /// <param name="price"></param>
        public BinomialHeap(ref T rootnode, uint price):this()
        {
            BinomialTreeNode<T> newNode = new BinomialTreeNode<T>(ref rootnode, price);
        }

        /// <summary>
        /// Merges two binomial heaps
        /// </summary>
        public void merge(BinaryHeap<T> heap) 
        {
        }

        /// <summary>
        /// Merges two heaps together trivially if the order is
        /// the same. 
        /// </summary>
        /// <param name="heap"></param>
        protected void mergeEquivalentOrder(BinaryHeap<T> heap)
        {

        }

        /// <summary>
        /// Inserts an item into the heap.
        /// Not optimal implementation for 
        /// indexing the nodes - see
        /// 
        /// http://www.cs.princeton.edu/~wayne/cs423/lectures/heaps-4up.pdf
        /// 
        /// for a better one
        /// </summary>
        /// <param name="item"></param>
        public override void Add(T item, uint price)
        {
            System.Diagnostics.Debug.WriteLine("Started adding");

            BinomialTreeNode<T> newNode = new BinomialTreeNode<T>(ref item, price);
            BinomialTreeNode<T> comparedNode;     // pointer to a compared node.
            int rootNodeIndex = 0;        // points to the index in the rootNodes 

            System.Diagnostics.Debug.WriteLine("Starting loop");
            while (rootNodes[rootNodeIndex] != null) 
            {
                comparedNode = rootNodes[rootNodeIndex];
                if (comparedNode.getPrice() > newNode.getPrice())
                {
                    comparedNode.setParent(ref newNode);
                    newNode.addChildTree(comparedNode);
                }
                else
                {
                    comparedNode.addChildTree(newNode);
                    newNode.setParent(ref comparedNode);
                    newNode = comparedNode;
                }
                rootNodes[rootNodeIndex] = null;
                rootNodeIndex++;  
 
                // if root index is out of range, add a new node
                if (rootNodeIndex > rootNodes.Count - 1)
                {
                    System.Diagnostics.Debug.WriteLine("Adding a new null position");
                    rootNodes.Add(null);
                }
            }

            rootNodes[rootNodeIndex] = newNode;
        }

       

        /// <summary>
        /// Return a minimum
        /// </summary>
        /// <returns></returns>
        public T minimum() 
        {
            return rootNodes[0].getValue();
        }

        /// <summary>
        /// Removes the minimum of heap
        /// </summary>
        public void removeMinimum() 
        {
        }
    }
}
