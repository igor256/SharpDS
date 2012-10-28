using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDS;
using SharpDS.ds.abs;

/// <summary>
/// Binary Heap implementation in C#.
/// Classic version using list for
/// storing all the data.
/// 
/// Nothing more and nothing less.
/// Made with love in London!
/// </summary>
/// <typeparam name="T"></typeparam>
namespace SharpDS.ds.binaryheap
{
    /// <summary>
    /// Binary Heap implementation. Nothing more and nothing less.  Made with love in London!
    /// </summary>
    /// <typeparam name="T">Type of the object contained in the heap</typeparam>
    class BinaryHeap<T>:SharpDS<T>
    {
        private List<BinaryTreeNode<T>> data; // data stored in the heap, heap formated
       
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
        /// Overload considering int as an input
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        public void Add(T item, int price)
        {
            Add(item, (uint) price);
        }

        /// <summary>
        /// Inserts an element into the rooted binary heap.
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


        /// <summary>
        /// Removes the root element from the data structure
        /// </summary>
        /// <returns></returns>
        public T RemoveRoot() 
        {
            int cnt = data.Count; // no of elements stored in the heap
            if (cnt == 0)         // if no elements are present, return T
                return default(T);

            T toReturn = data[0].getValue(); // get the first element stored
            
            int elementIndex = 0;            // stores an information of the new root's position when downheap.
            int leftChildIndex = 0;          // stores an info about leftChild
            int rightChildIndex = 0;         // stores an info about rightChild
            int downIndex = 0;               // index of the down element to swap

            BinaryTreeNode<T> node;
            BinaryTreeNode<T> leftChild;
            BinaryTreeNode<T> rightChild;
            BinaryTreeNode<T> compared;

            node = data.Last();           // first element is equal to last.
            data[0] = node;
            data.RemoveAt(cnt - 1);          // last item is removed

            bool scan = true;                // scan
            while (scan) 
            {
                leftChildIndex  = (elementIndex * 2) + 1;
                rightChildIndex = (elementIndex * 2) + 2;

                leftChild  = leftChildIndex  < cnt-1 ? data[leftChildIndex] : null;
                rightChild = rightChildIndex < cnt-1 ? data[rightChildIndex]: null;

                if (leftChild == null)
                    break;

                if (rightChild == null)
                {
                    compared = leftChild;
                    downIndex = leftChildIndex;
                    goto comparation;
                }

                // if left child is lower than right, prefer it for comparisson
                if (rightChild.getPrice() > leftChild.getPrice()){
                    downIndex = leftChildIndex;
                    compared  = leftChild;
                } else{
                    downIndex = rightChildIndex;
                    compared  = rightChild;
                }

                comparation:
                {
                    // if compared price is higher than node price
                    if (compared.getPrice() < node.getPrice())
                    {
                        data[elementIndex] = compared;
                        data[downIndex] = node;

                        elementIndex = downIndex;
                    }
                    else
                        break; // heapified
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Returns a string representing the heap
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            string s = "";
            foreach (BinaryTreeNode<T> o in data) 
            {
                s += o.getPrice() + ", ";
            }
            return s;
        }
    }
}
