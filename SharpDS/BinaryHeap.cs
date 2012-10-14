using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDS;
using System.Collections.Generic;
namespace SharpDS
{
    /// <summary>
    /// Binary Heap implementation in C#.
    /// Classic version using list for
    /// storing all the data.
    /// 
    /// Nothing more and nothing less. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BinaryHeap<T>:SharpDS<T>
    {
        private List<BinaryTreeNode<T>> data; // data stored in the heap, heap formated
        private BinaryTreeNode<T> root; // stores the root element of binary heap

        public BinaryHeap():base()
        {
            data = new List<BinaryTreeNode<T>>();
        }

        /// <summary>
        /// Adds an item to the heap. Overrides really?
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item, uint price)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(ref item, price);
            push(node);
        }

        /// <summary>
        /// Inserts an element element into the rooted binary heap.
        /// </summary>
        private void push(BinaryTreeNode<T> element) 
        {
            int parentIndex;               // denotes an index of parent to element
            int elementIndex = data.Count; // returns an index at which the element will be positioned
            data.Add(element);             // adds the element to that index.

            bool scan = true;              // while scan, sort the elements in the heap accordingly
            while (scan) 
            {
                parentIndex = ((elementIndex -1) >> 1); // obtain the index of parent 

                if (elementIndex == 0 || data[elementIndex].getPrice() >= data[parentIndex].getPrice()) // min-heap property
                    break; // element at place stop searching (stops even if element is root)

                data[elementIndex] = data[parentIndex]; // swaps the parent and element
                data[parentIndex]  = element;           // data[parentIndex] is element

                elementIndex = parentIndex;
            }
        }

        /// <summary>
        /// Returns a root element without removing it
        /// from the data structure
        /// </summary>
        /// <returns>Root element, or default value of heap type</returns>
        public T Peek()
        {
            return data.Count > 0 ? data[0].getValue() : default(T);
        }

        public override void Add(T item)
        {
            throw new NotImplementedException();
        }
    }
}
