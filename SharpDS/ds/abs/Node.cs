using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpDS.ds.abs
{
    /// <summary>
    /// Provides a simple root level container for
    /// data stored in SharpDS
    /// </summary>
    public class Node<T>
    {
        private T value; // value contained in the node
        protected int price;          // price of the node
		
        public Node() 
        {
        }
		
		public Node(ref T item, int price)
		{
			setValue(ref item);
			setPrice(price);
		}

        /// <summary>
        /// Returns the value stored in node
        /// </summary>
        /// <returns></returns>
        public T getValue() 
        {
            return value;
        }

        /// <summary>
        /// Sets a reference to the value given in argument
        /// for the node.
        /// </summary>
        /// <param name="value"></param>
        public void setValue(ref T value)
        {
            this.value = value;
        }
        
		
        /// <summary>
        /// Sets the price of the node to value
        /// </summary>
        /// <param name="value"></param>
        public void setPrice(int value)
        {
            price = value;
        }

        /// <summary>
        /// Returns the price for the node
        /// </summary>
        /// <returns></returns>
        public int getPrice()
        {
            return price;
        }
		
    }
}
