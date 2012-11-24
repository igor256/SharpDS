using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpDS.ds.abs;
using SharpDS.ds.binaryheap;

namespace SharpDS.ds.binomialheap
{
	/**
	 * TODO: 
	 * ensure the rootnodes are removed correctly
	 * 
	 */ 
    /// <summary>
    /// SharpDS implementation of binomial heap.
    /// 
    /// For fast merge operations and fun :D 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BinomialHeap<T>:Heap<T>
    {
        public List<BinomialTreeNode<T>> rootNodes; // contains an array of root nodes of trees in the heap. BinaryHeap used for prioritising

        /// <summary>
        /// Default constructor for the binomial heap
        /// </summary>
        public BinomialHeap()
        {
            rootNodes = new List<BinomialTreeNode<T>>();
            rootNodes.Add(null); // prepare null at first index (improve);
        }

        /// <summary>
        /// Creates a new binomial heap with a first rootnode inserted
        /// </summary>
        /// <param name="rootnode"></param>
        /// <param name="price"></param>
        public BinomialHeap(ref T rootnode, int price):this()
        {
            BinomialTreeNode<T> newNode = new BinomialTreeNode<T>(ref rootnode, price);
        	rootNodes[0] = newNode;
		}

        /// <summary>
        /// Protected constructor for creating a BH from a list of rootnodes.
        /// Assuming rootNodeList is non-null and contains at least one element.
        /// </summary>
        /// <param name="heap">A non-null list of rootNode elements</param>
        protected BinomialHeap(List<BinomialTreeNode<T>> rootNodeList) 
        {
            rootNodes = rootNodeList;
        }

        /// <summary>
        /// Merges two binomial heaps
        /// </summary>
        public BinomialHeap<T> Merge(BinomialHeap<T> heap) 
        {
            // returns a merged binomial heap
            return Merge(heap.getRootNodes());
        }

        /// <summary>
        /// Merges the heap with a new one 
        /// </summary>
        /// <param name="newRootNodes"></param>
        /// <returns></returns>
        public virtual BinomialHeap<T> Merge(List<BinomialTreeNode<T>> newRootNodes)
        {
            BinomialHeap<T> newHeap;

            int traversalLength; // how many consequent indices shall i check?
            int firstend;        // how many consequent indices before nullity of one list occurs?
            List<BinomialTreeNode<T>> shorter; // contains the shorter rootnode list
            List<BinomialTreeNode<T>> longer;  // contains the longer rootnode list

            if (newRootNodes.Count > rootNodes.Count) // Could be done wiser probably
            {
                traversalLength = newRootNodes.Count;
                firstend        = rootNodes.Count;
                longer          = newRootNodes;
                shorter         = rootNodes;
            }
            else
            {
                traversalLength = rootNodes.Count;
                firstend        = newRootNodes.Count;
                longer          = rootNodes;
                shorter         = newRootNodes;
            }

            List<BinomialTreeNode<T>> newList = new List<BinomialTreeNode<T>>(traversalLength + firstend); // a list of new rootNodes - is the trL + fe the right length
            
			for(int i = 0; i < traversalLength + firstend; i++) // this should be avoided... 
				newList.Add(null);
			
            // Traversal - here must be the mistake!
            for (int i = 0; i < traversalLength; i++)
            {			
                BinomialTreeNode<T> subTreeNodeShort = null;
                if (i < firstend)
                {
                    subTreeNodeShort = shorter[i];
                }

                BinomialTreeNode<T> subTreeNodeLong = longer[i];
				
				if(subTreeNodeLong == null && subTreeNodeShort != null)
					newList[i] = mergeSubtrees(newList[i],subTreeNodeShort);
				else if (subTreeNodeLong != null && subTreeNodeShort == null)
					newList[i] = mergeSubtrees(newList[i],subTreeNodeLong);
				else if(subTreeNodeLong == null && subTreeNodeShort == null)
					newList[i] = mergeSubtrees(newList[i],null);
				else if(subTreeNodeShort != null && subTreeNodeLong != null)
				{
				    newList[i+1] = mergeSubtrees(subTreeNodeLong, subTreeNodeShort);
				}
					                
            } // end of traversal

            // construct a merged bh
            newHeap = new BinomialHeap<T>(newList);

            // returns a merged binomial heap
            return newHeap;
        }

        /// <summary>
        /// Merges two subtrees with rootnodes given in the argument,
        /// returns parent.
        /// </summary>
        /// <param name="rootNode1"></param>
        /// <param name="rootNode2"></param>
        protected BinomialTreeNode<T> mergeSubtrees(BinomialTreeNode<T> rootNode1,BinomialTreeNode<T> rootNode2) 
        {
            BinomialTreeNode<T> parent;
			if(rootNode1 == null)
				parent = rootNode2;
			else if (rootNode2 == null)
				parent = rootNode1;
            else if (rootNode1.getPrice() > rootNode2.getPrice())
            { 
				rootNode2.addChildTree(rootNode1);
                parent = rootNode2;
            }
            else
            {
                rootNode1.addChildTree(rootNode2);
                parent = rootNode1;
            }

            return parent;
        }

      
        /// <summary>
        /// Inserts an item into the heap.
        /// Not optimal implementation for 
        /// indexing the nodes - see
        /// 
        /// http://www.cs.princeton.edu/~wayne/cs423/lectures/heaps-4up.pdf
        /// 
        /// for a better one
        /// </summary>
        /// <param name="item"></param>
        public override void Add(T item, int price)
        {
           
            BinomialTreeNode<T> newNode = new BinomialTreeNode<T>(ref item, price);
            BinomialTreeNode<T> comparedNode;     // pointer to a compared node.
            int rootNodeIndex = 0;        // points to the index in the rootNodes 

            while (rootNodes[rootNodeIndex] != null) 
            {
                comparedNode = rootNodes[rootNodeIndex];
                if (comparedNode.getPrice() > newNode.getPrice())
                {
                  //  comparedNode.setParent(ref newNode);
                    newNode.addChildTree(comparedNode);
                }
                else
                {
                    comparedNode.addChildTree(newNode);
                   // newNode.setParent(ref comparedNode);
                    newNode = comparedNode;
                }
                rootNodes[rootNodeIndex] = null;
                rootNodeIndex++;  
 
                // if root index is out of range, add a new node
                if (rootNodeIndex > rootNodes.Count - 1)
                {
					rootNodes.Add(null);
                }
            }

            rootNodes[rootNodeIndex] = newNode;
        }

       

        /// <summary>
        /// Return a minimum.
        /// Implemented using just by going through 
        /// an array using O(N).
        /// 
        /// Could be probably done better. Not sure
        /// how well the Min<> method of List is 
        /// implemented though.
        /// </summary>
        /// <returns>The leftmost minimum</returns>
        public override T Peek() 
        {
            BinomialTreeNode<T> btn = minimumNode();
            if (btn != null)
                return btn.getValue();
            else
                return default(T); //here we go!

        }

        /// <summary>
        /// Returns a minimumNode from the rootNode
        /// list.
        /// </summary>
        /// <returns></returns>
        protected BinomialTreeNode<T> minimumNode() 
        {
            /// Check if something is contained in the heap
            if (rootNodes.Count == 0)
                return null;

            BinomialTreeNode<T> toReturn = rootNodes[0];
            foreach (BinomialTreeNode<T> btn in rootNodes)
            {
                if (btn == null)
                    continue;

                if (toReturn == null)
                {
                    toReturn = btn;
                    continue;
                }

                if (toReturn.getPrice() > btn.getPrice())
                {
                    toReturn = btn;
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Removes the minimum of heap.
        /// Reheaps.
        /// 
        /// Note: the removal is implemented via
        /// List.Remove(Node). That is not efficient
        /// and could be improved.
        /// 
        /// Not yet ready.
        /// 
        /// </summary>
        public override void RemoveMinimum() 
        {
            BinomialTreeNode<T> minRootNode    = minimumNode();
			
			if(minRootNode == null){
				return;
			}
			
            List<BinomialTreeNode<T>> children = minRootNode.getChildren();
	

            int i        = rootNodes.IndexOf(minRootNode); // Removes the min root node
            rootNodes[i] = null; // nulls the index

            // set the parents to null and add the node into the heap. 
            // check if this is correctly implemented
            BinomialHeap<T> clone = Merge(children);
            this.rootNodes = clone.rootNodes;
        }

        /// <summary>
        /// Returns a list of the rootNodes
        /// </summary>
        /// <returns></returns>
        protected List<BinomialTreeNode<T>> getRootNodes()
        {
            return rootNodes;
        }
    }
}
