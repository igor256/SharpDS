using System;

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
			
		}
		/// <summary>
		/// Creates a new FibonacciHeap with minimumn node
		/// </summary>
		public FibonacciHeap (T value, int price):base()
		{
		   minimumNode = new FibonacciTreeNode<T>(ref value, price);
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
			FibonacciHeap<T> heap = new FibonacciHeap<T>(ref item, price);
			Merge(heap);
		}
		
		/// <summary>
		/// Removes the minimum.
		/// </summary>
		public override void RemoveMinimum ()
		{
			// keep the references
			nodesLeft  = minimumNode.getLeft();
			nodesRight = minimumNode.getRight();
			
			// unlink the min node
			minimumNode.unlink();
			List<FibonacciTreeNode<T>> children = minimumNode.getChildren();			
		}
		
		/// <summary>
		/// Merge the specified heap with this one
		/// </summary>
		public void Merge(FibonacciHeap<T> heap)
		{			
			// Special cases:
			if(minimumNode == null) // minnode is null
			{
				minimumNode = heap.minimumNode;
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
			if(heap.minimumNode < minimumNode)
			   this.minimumNode = heap.minimumNode;
				
		}
		
	}
}

