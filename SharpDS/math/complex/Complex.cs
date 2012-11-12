using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace SharpDS.math.complex
{
    class Complex
    {

        private float imaginary;
        private float real;

        /// <summary>
        /// A complex number representation
        /// </summary>
        public Complex(float real, float imaginary) 
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        /// <summary>
        /// Blank constructor for 0+0i
        /// </summary>
        public Complex() 
        {
            real = 0;
            imaginary = 0;
        }

        /// <summary>
        /// Adds two complex numbers
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
        }

        public static Complex operator -(Complex c1, Complex c2) 
        {
            return new Complex(c1.real - c2.real, c1.imaginary - c2.imaginary);
        }

        public static Complex operator -(Complex c1) 
        {
            return new Complex(-c1.real, -c1.imaginary);
        }

        public static Complex operator *(Complex c1, Complex c2) 
        {
            return new Complex(c1.real * c2.real - c1.imaginary * c2.imaginary, c1.real * c2.imaginary + c2.real * c1.imaginary);
        }

        public static Complex operator *(Complex c1, float f) 
        {
            return new Complex(c1.real * f, c1.imaginary * f);
        }

        public static Complex operator *(float f, Complex c1)
        {
            return c1 * f;
        }

        /// <summary>
        /// Makes a complex conjugate :D
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        public static Complex operator ~(Complex c1)
        {
            return new Complex(c1.real, -c1.imaginary);
        }

        /// <summary>
        /// returns modulus of the complex number
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        public static float mod(Complex c1) 
        {
            return (float) Math.Sqrt(mod2(c1));
        }

        /// <summary>
        /// returns mod. squared
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        public static float mod2(Complex c1) 
        {
            return (c1 * ~c1).real;
        }

        /// <summary>
        /// returns pow(c1,-1) 
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        public static Complex inverse(Complex c1) 
        {
            float m = mod2(c1);
            return new Complex(c1.real / m, -c1.imaginary / m); 
        }

        /// <summary>
        /// division by float:
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Complex operator /(Complex c1, float f1)
        {
            return new Complex(c1.real / f1, c1.imaginary / f1);
        }

        /// <summary>
        /// Makes a division 
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Complex operator /(Complex c1, Complex c2) 
        {
            return c1 * inverse(c2);
        }
        
        
        /// <summary>
        /// Returns a traceable string for complex number;
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            return real + " + " + imaginary + "i";
        }
      
    }
}
