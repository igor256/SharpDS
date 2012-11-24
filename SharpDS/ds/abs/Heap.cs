using System;

namespace SharpDS.ds.abs
{
	/// <summary>
	/// Heap abstract implementation to be extended by various kinds of Heap
	/// </summary> 
	public abstract class Heap<T>:SharpDS<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SharpDS.Heap`1"/> class.
		/// </summary>
		public Heap ()
		{
			
		}
		
		/// <summary>
		/// Returns the value of the first element in the SharpDS (ie. minimum of heap)
		/// </summary>
		public abstract T Peek();
		
		/// <summary>
		/// Removes the minimum node.
		/// </summary>
		public abstract void RemoveMinimum();
	}
}

