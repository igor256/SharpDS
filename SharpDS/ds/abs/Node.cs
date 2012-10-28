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
    class Node<T>
    {
        private T value; // value contained in the node
        
        public Node() 
        {
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
        
    }
}
