using System;
using System.Collections.Generic;
using SharpDS.ds.abs;
using SharpDS.ds.binomialheap;

/// <summary>
/// Fibonacci tree node.
/// Children are stored in List instance for simplicity.ould be better using LL.
/// </summary>
namespace SharpDS.ds.fibonacciheap
{
	/// <summary>
	/// Fibonacci tree node class for the fibonacci heap data structure
	/// 
	/// Doubly-linked circular list logic is implemented into the node.
	/// </summary>
	public class FibonacciTreeNode<T>:Node<T>
	{
		private bool marked = false; // is marked?
		private List<FibonacciTreeNode<T>> _children;
		
		/// For doubly linked circular list
		protected FibonacciTreeNode<T> left;  // reference to the left sibling 
		protected FibonacciTreeNode<T> right; // ref to the right sibling
		
	
		public FibonacciTreeNode(ref T value, int price):base(ref value, price)
		{
			left = this;
			right = this;
			_children = new List<FibonacciTreeNode<T>>(); // Initializes the FibonacciList
		}
		
		/// <summary>
		/// Is marked?
		/// </summary>
		public bool isMarked()
		{
			return marked;
		}
		
		/// <summary>
		/// Sets the value for marked
		/// </summary>
		public void setMarked(bool val)
		{
			marked = val;
		}
		
		/// <summary>
		/// Returns rank of the instance
		/// </summary>
		public int rank
		{
			get{return getChildren().Count; }
		}
		
		/// <summary>
		/// Gets or sets the children.
		/// </summary>
		public List<FibonacciTreeNode<T>> getChildren(){
				return this._children;
		}
		
		/// <summary>
		/// Adds the child to he children list and increases rank
		/// of the Node. (rank is 
		/// </summary>
		public void AddChild(FibonacciTreeNode<T> child)
		{
			_children.Add(child);
		}
		
		
		/// <summary>
		/// Sets the left.
		/// </summary>
		public void setLeft(FibonacciTreeNode<T> val)
		{
			left = val;
		}
		
		/// <summary>
		/// Gets the left sibling.
		/// </summary>
		public FibonacciTreeNode<T> getLeft()
		{
			return left;
		}
		
		/// <summary>
		/// Sets the right sibling
		/// </summary>
		public void setRight(FibonacciTreeNode<T> val)
		{
			right = val;
		}
		
		/// <summary>
		/// Gets the right sibling
		/// </summary>
		public FibonacciTreeNode<T> getRight()
		{
			return right;
		}
		
		/// <summary>
		/// Unlink this instance from the circular doubly-linked list.
		/// Connects the list
		/// </summary>
		public void Unlink()
		{
			
			// identify singleton
			if(this.left == null)
				return;
			
			// if removing last of two nodes
			if(left.getLeft() == this){
				left.setRight(null);
				left.setLeft(null);
				return;
			}
			
			// otherwise just connect siblings
			this.left.setRight(right);
			this.right.setLeft(left);
		}

		/// <summary>
		/// Unlinks the instance without connecting the doubly-linked list
		/// </summary>
		public void HardUnlink()
		{
			// otherwise just connect siblings
			if(this.getRight() != null)
				this.getRight().setLeft(null);
			if(this.getLeft() != null)
				this.getLeft().setRight(null);
			
			setLeft(null);
			setRight(null);
		}
		
		
	}
}

