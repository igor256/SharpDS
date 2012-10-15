using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpDS.math.complex;

namespace SharpDS.math.matrix
{
    class SquareMatrix:Matrix
    {
        /// <summary>
        /// Dimensionality of matrix.
        /// </summary>
        private int dim;

        /// <summary>
        /// Represents a square matrix of a dimension d
        /// </summary>
        /// <param name="dim"></param>
        public SquareMatrix(int dim) : base(dim, dim) 
        {
            this.dim = dim;
        }

        /// <summary>
        /// Returns a determinant of a matrix.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Complex det()
        {
            // if only one element is present, return that element.
            if (rows == 1 && cols == 1)
                return getAt(0, 0);

            // if not, find a determinant of submatrix.
            Complex toReturn = new Complex();
           
            for (int j = 0; j < cols; j++) 
            {
                SquareMatrix sqm = submatrix(0, j);
                toReturn += leviCivita(0,j)*getAt(0,j)*sqm.det();
            }
            
            return toReturn;
        }

        /// <summary>
        /// Returns a Kroenecker delta symbol.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private int kroenecker(int i, int j) 
        {
            if (i == j)
                return (1);
            return 0;
        }

        /// <summary>
        /// Returns leviCivita symbol.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private int leviCivita(int i, int j)
        {
            if ((((i + j) >> 1) << 1) == (i + j))
                return -1;
            return 1;
        }

        /// <summary>
        /// Returns a matrix corresponding to a minor to a given element in the original matrix.
        /// This has a dimensionality of N-1. Whop!
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public SquareMatrix submatrix(int i, int j) 
        {
            SquareMatrix toReturn = new SquareMatrix(dim-1);
            
            int minus_k = 0;
            int minus_l = 0;

            for (int k = 0; k < dim; k++) 
            {
                minus_l = 0;
                for (int l = 0; l < dim; l++) 
                {
                   if(l == j){
                       minus_l = -1;
                       continue;
                   }
                   if (k == i) 
                   {
                       minus_k = -1;
                       continue; //this should break the small for.
                   }
                   toReturn.setAt(getAt(k, l), k + minus_k, l + minus_l);
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Returns a trace of the matrix.
        /// </summary>
        /// <returns></returns>
        public Complex trace() 
        {
            Complex sum = new Complex();
            for (int i = 0; i < dim; i++)
                sum += getAt(i, i);

            return sum;
        }

        
    }
}
