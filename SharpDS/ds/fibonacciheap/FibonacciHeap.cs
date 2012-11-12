using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpDS.ds.abs;

namespace SharpDS.ds.fibonacciheap
{
	/// <summary>
	/// Fibonacci heap SharpDS implementation.
	/// 
	/// For faster amortized time and Dijskra! 
	/// </summary>
	public class FibonacciHeap<T>:SharpDS<T>, MergeableDS<T>
	{
		public FibonacciHeap ()
		{
			Console.WriteLine("mmm");
		}
	}
}

