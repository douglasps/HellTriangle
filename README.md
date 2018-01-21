# HellTriangle
Given a triangle of numbers, find the maximum total from top to bottom
```
Example:
6
3 5
9 7 1
4 6 8 4
In this triangle the maximum total is: 6 + 5 + 7 + 8 = 26
An element can only be summed with one of the two nearest elements in the next row.
For example: The element 3 in the 2nd row can only be summed with 9 and 7, but not with
1
Your code will receive an (multidimensional) array as input.
The triangle from above would be:
example = [[6],[3,5],[9,7,1],[4,6,8,4]]
```

## Why c#
C# it's my main programming language, I work with C# for about 5 years now and already use the native test library of .Net 4.5. This exercise doesn't seem have advantages to be done in any particular programming language, that's why I chose one that I am faster using.

## Prerequisites
- Visual Studio 2013 or above (with .Net framework 4.5 or above installed)

## Setup:
- Open the solution in Visual Studio 2013 or above, because the test library used works in .Net framework 4.5 or above (this project was created in vs 2017 .Net framework 4.5).
- In the "Test" menu of visual studio click on the option Test >> Run >> All tests, or Ctrl + R, A.
- The tests will be run and displayed the runtimes in the Test Explorer;
- The tests are in the project "HellTriangle.Tests" and the code that makes the calculation is in the project "HellTriangle"

## How to buit it:
The code consists in navigating the multidimensional array through recursion. The recursive method receives the Y axis index, the X axis index, and the multidimensional array calling the same method passing the parameters to the next Y axis by comparing the left "child" with the right "child".

## Algorithm Complexity
A complexity of the algorithm is O(n) because it uses recursion.
