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
    class BinaryTreeNode<T>:HeapNode<T>
    {
        public BinaryTreeNode(ref T value, int price) : base(ref value, price) { }
            
    }
}
