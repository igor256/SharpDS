using System;
using System.Collections.Generic;

using SharpDS.ds.abs;

namespace SharpDS.ds.abs
{
	
	/// <summary>
	/// 
	/// Interface for dynamic structures implementing merging.
	/// </summary>
	public interface MergeableDS<T>
	{
		 SharpDS<T> Merge(SharpDS<T> heap);
		 SharpDS<T> Merge(ICollection<Node<T>> newRootNodes);
	}
}

