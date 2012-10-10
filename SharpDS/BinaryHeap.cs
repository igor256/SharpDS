using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDS;

namespace SharpDS
{
    /// <summary>
    /// Binary Heap implementation in C#
    /// 
    /// Nothing more and nothing less. 
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BinaryHeap<T>:SharpDS<T>
    {
        private BinaryTreeNode<T> root; // stores the root element of binary heap
        private BinaryTreeNode<T> last; // stores the last element of bh.
        public BinaryHeap():base()
        {
            
        }

        /// <summary>
        /// Adds an item to the heap. Overrides really?
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item, uint price)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(ref item, price);

            if (root == null) // if there is no element in the heap:
            {
                root = node; // root is node now
                last = node; // last is node as well
                return;
            }


            last = node;

        }
    }
}
