using System;
using System.Collections.Generic;

using SharpDS.ds.abs;
using SharpDS.ds.binomialheap;

/// <summary>
/// This does not work for some reason...
/// </summary>
namespace SharpDS.ds.fibonacciheap
{	
	/// <summary>
	/// Fibonacci heap SharpDS implementation.
	/// 
	/// For faster amortized time and Dijskra! 
	/// 
	/// Based on paper by Fredman & Tarjan:
	/// Fibonacci Heaps and their uses in improved network optimization algorithms.
	/// 
	/// </summary>
	public class FibonacciHeap<T>:Heap<T>
	{
		public FibonacciTreeNode<T> minimumNode = null;     // pointer to minimum nodes
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SharpDS.ds.fibonacciheap.FibonacciHeap`1"/> class.
		/// </summary>
		public FibonacciHeap ():base()
		{
			_size = 0;	
		}
		/// <summary>
		/// Creates a new FibonacciHeap with minimumn node
		/// </summary>
		public FibonacciHeap (T value, int price):base()
		{
		   minimumNode = new FibonacciTreeNode<T>(ref value, price);
		   _size = 1;
		} 
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SharpDS.ds.fibonacciheap.FibonacciHeap`1"/> class.
		/// </summary>
		public FibonacciHeap (ref FibonacciTreeNode<T> node):base()
		{
			minimumNode = node;
			_size = 1;
		}
		
		/// <summary>
		/// Returns the minimum node value from the heap. 
		/// Note - Dangerous null!
		/// </summary>
		public override T Peek ()
		{
			if(minimumNode == null)
				return default(T);
			
			return minimumNode.getValue();
		}
		
		/// <summary>
		/// Add the specified item.
		/// </summar>
		public override void Add(T item, int price)
		{
			FibonacciHeap<T> heap = new FibonacciHeap<T>(item, price);
			Merge(heap);
		}
		
		/// <summary>
		/// Removes the minimum.
		/// </summary>
		public override void RemoveMinimum ()
		{			
			// Note: 
			// the implementation here differs slightly from Fredman & Tarjan
			// since the lists are not merged before performing the insertion
			// step.
			if(size == 0) 
				return; // Immediate fallback if 0 sized
			
			// Returns the children of the node
			List<FibonacciTreeNode<T>> children = minimumNode.getChildren();	
			
			// Implement the filling of the ranks array!
			int maxRank = (int) size-1+minimumNode.rank;                      // TODO: what is the max rank of any node if there are n + m nodes present? Check
			FibonacciTreeNode<T>[] ranks = new FibonacciTreeNode<T>[maxRank]; // Array containing rootnodes indexed by rank
			
			FibonacciTreeNode<T> nodesRight = minimumNode.getRight();
			
			// Unlink the min node
			minimumNode.unlink(); // the circular linked list is now splitted
			minimumNode = nodesRight;
				
			
			// Performing the insertion step for circular list of rootnodes without minimum
			while(nodesRight != null) // Loops through all items in the circular list except the minimum node
			{
				InsertionStep(ref ranks, nodesRight);
				// Repoints to the right sibling
				nodesRight = nodesRight.getRight();
			}
			
			// Performing the insertion step for children of the min node
			foreach(FibonacciTreeNode<T> node in children)
			{
				InsertionStep(ref ranks, node);
			}
			
			// All nodes should be now 
			// reheapified and inserted 
			// in the ranks array
			
			// Assuming this step was successful, this should work:
			int length = ranks.GetLength(0);
			
			// Scanning ranks array:
			for(int i = 0; i < length; i++)
			{
				// Omits nulls and prepares reference for first.
				if(ranks[i] == null)
					continue;
				
				// Assigns the content to root variable.	
				FibonacciTreeNode<T> root = ranks[i]; 
				FibonacciHeap<T>    heap = new FibonacciHeap<T>(ref root);
				
				// Update minimum Node
				if (root.getPrice() < minimumNode.getPrice())
					minimumNode = root; // If node with lower price is scanned, exchange.
				
				Merge(heap);
			}			
			
			// This should be it.
			_size --;
	
		}
		
	 	/// <summary>
	 	/// Procedure.
	 	/// 
	 	/// Performs an insertion step on 
	 	/// ranks array reference using target node.
	 	/// </summary>
		private void InsertionStep(ref FibonacciTreeNode<T>[] ranks, FibonacciTreeNode<T> nodesRight)
		{
			FibonacciTreeNode<T> inList = ranks[nodesRight.rank]; // node contained in the list at given rank
			FibonacciTreeNode<T> toSlot = nodesRight;             // node at given position
			
			// If the position in ranks array 
			// is already filled up, merge the 
			// two nodes and add them to rank+1 slot
			while(inList != null){
				toSlot = LinkingStep(inList, toSlot);
				ranks[toSlot.rank-1] = null; // Nulls the left position
				inList = ranks[toSlot.rank]; // Looks for the higher rank and eventually loops
			}
					
			// inserts the toSlot item into the array
			ranks[toSlot.rank] = toSlot;
		}
		
		/// <summary>
		/// Links two nodes of same rank 
		/// according their price (lowest 
		/// price up)
		/// </summary>
		/// <returns>
		/// Linked node with rank = rank + 1
		/// </returns>
		private FibonacciTreeNode<T> LinkingStep (FibonacciTreeNode<T> node1, FibonacciTreeNode<T> node2)
		{
			FibonacciTreeNode<T> higher; // higher priced node
			FibonacciTreeNode<T> lower;  // lower priced node
			
			// Adds the children to 
			if(node1.getPrice() > node2.getPrice()){
				higher = node1;
				lower  = node2;
			}
			else{
				higher = node2;
				lower  = node1;
			}

			//higher.unlink(); // delete references of childnode - the references are needed still at this stage to loop through the list!
			lower.AddChild(higher); // makes higher a child of lower
			
			return lower; // returns lower priced node
		}
		
		/// <summary>
		/// Merge the specified heap with this one
		/// </summary>
		public void Merge(FibonacciHeap<T> heap)
		{			
			
			// Special cases:
			if(minimumNode == null) // minnode is null
			{
				System.Console.WriteLine("what should happen happened");
				minimumNode = heap.minimumNode;
				_size = heap._size;
				return;
			}
			
			if(heap.minimumNode == null) // heap.minnode is null - do nothing
				return;
				
			// Concenates the lists:
			FibonacciTreeNode<T> last = minimumNode.getLeft();	// keeps a reference to left node
			FibonacciTreeNode<T> heapLast = heap.minimumNode.getLeft();
			
			last.setRight(heap.minimumNode);
			heap.minimumNode.setLeft(last);
			
			minimumNode.setLeft(heapLast);
			heapLast.setRight(minimumNode);
			
			/// Updates heapnodes
			if(heap.minimumNode.getPrice() < minimumNode.getPrice())
			   this.minimumNode = heap.minimumNode;
				
			// Increases the heap size
			_size += heap._size;
		}
		
	}
}

