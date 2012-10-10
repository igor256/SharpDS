using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDS;

namespace SharpDS
{
    
     abstract class SharpDS<T>
    {
       

        /// <summary>
        /// Provides a basic root class for all data strutures 
        /// in the package.
        /// </summary>
        public SharpDS() 
        {
        }

        /// <summary>
        /// Provides a method of adding an entry to the data structure. 
        /// </summary>
        public abstract void Add(T item);

        /// <summary>
        /// Provides an access to the total number of elements stored in the ds
        /// </summary>
        private uint _size = 0;
        public uint size
        {
            get { return _size; }
        } 
    }
}
