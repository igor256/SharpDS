using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpDS.math.complex;

namespace SharpDS.math.matrix
{
    /// <summary>
    /// A class representing a mathematical matrix.
    /// </summary>
    class Matrix
    {
        Complex[][] data;
        public int cols;
        public int rows;

        /// <summary>
        /// Creates a new matrix object ready to be used
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public Matrix(int rows, int cols) 
        {
            this.cols = cols;
            this.rows = rows;

            data = new Complex[rows][];
            for (int i = 0; i < rows; i++)
                data[i] = new Complex[cols];
        }

        /// <summary>
        /// Creates a new Matrix object from array data
        /// </summary>
        /// <param name="data"></param>
        public Matrix(Complex[][] data) 
        {
            this.data = data;
            rows = data.Length;
            cols = data[0].Length;
        }

        /// <summary>
        /// Transposes the given matrix
        /// </summary>
        /// <returns></returns>
        public Matrix transpose(Matrix mtx) 
        {
            // create new matrix with interchanged cols and rows:
            Matrix toReturn = new Matrix(cols, rows);

            for (int i = 0; i < rows; i++) 
            {
                for (int j = 0; j < cols; j++) 
                {
                    toReturn.setAt(getAt(i,j), j, i);
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Sets a given value to the position int i/j
        /// </summary>
        /// <param name="value"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void setAt(Complex value, int i, int j) 
        {
            data[i][j] = value;
        }

        /// <summary>
        /// Returns a value at i, j;
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public Complex getAt(int i, int j) 
        {
            return data[i][j];
        }

        /// <summary>
        /// Makes a test on possibility, then sums two matrices together
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator +(Matrix m1, Matrix m2) 
        {
            if (m1.cols != m2.cols || m1.rows != m2.rows)
                throw new ArgumentException("Matrices do not have the same num of rows/cols and cannot be added");

            Matrix toReturn = new Matrix(m1.rows, m1.cols);
            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.cols; j++)
                {
                    toReturn.setAt(m1.getAt(i, j) + m2.getAt(i, j), i, j);
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Returns a string representing the matrix:
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string toReturn = "";
            for (int i = 0; i < rows; i++) 
            {
                toReturn += "|";
                for (int j = 0; j < cols; j++)
                {
                    toReturn += (getAt(i, j).ToString());
                    if (j != cols - 1)
                        toReturn += ", ";
                }
                toReturn += ("|\n");
            }
            return toReturn;
        }
    }
}
