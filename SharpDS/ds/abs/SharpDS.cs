using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDS;

namespace SharpDS.ds.abs
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
        /// Provides an access to the total number of elements stored in the ds
        /// </summary>
        private uint __size = 0; // internal storage of size
        public uint size // what is seen outside
        {
            get { return _size; }
        }

        protected uint _size // what is seen in the package
        {
            set { __size = value; }
            get { return __size; }
        }

        public abstract void Add(T item, uint price);
       /* public void Add(T item, int price)
        {
            Add(item, (int) price);
        }*/
    }
}
