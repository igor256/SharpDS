SharpDS
=======
A set of lightweight data structures missing in C#. This library is highly 
experimental and not usable at the moment.

Docs:
------
Have a look at [wiki](SharpDS/wiki) for thorough documentation.

Contact:
--------
Feel free to drop me some lines at:
vojta[dot]havlicek[at]gmail[dot]com

Be sure to visit:
[flashlemonade.com](http://www.flashlemonade.com)

Updates:
-------
* 10/12/2012 -
Fibonacci Heap still being implemented. RemoveMinimum mehtod is faulty.

* 12/11/2012 -
The issues in binomial heap investigated. Faulty RemoveMinimum implementation found, repaired.
Some unnecessary steps at RemoveMinimum are causing the algorithm to be a bit slower at the moment.

* 11/11/2012 -
Implementing Fibonacci heap in progress. Some issues with default values on Peek() in Binomial 
heap were found when using data types.

* 06/11/2012 - 
Minor mistakes in binomial heap implementation corrected. Binomial heap 
implementation is working now!

* 05/11/2012 - 
Binomial heap implemented. To be tested properly.

* 02/11/2012 - 
BinomialHeap is being implemented! Work in progress version with implemented
Add is prepared. Merging soon!

* 27/10/2012 -
BinaryHeap is now prepared for use! Math package was added, containing stubs 
of Complex and Matrix classes for (suprisingly) complex + matrix computation.
Some operations are not yet supported, but most of the casual operators like
+,/,-,* are overloaded so it is now easier to work with comp + mtx. Determinant
computation supported as well!

------------------------
Made with love in London!

Vojtech Havlicek 2012