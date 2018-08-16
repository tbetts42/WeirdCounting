# Weird Counting Test Project #

This program was to test a bug we encountered with how
row numbers were being added to each line read from a CSV file.

Every time the list was accessed, the numbers would jump.

The solution was to use the Linq `.Select((item, index))` method.

A second solution was to add a `.ToList()` to the `IEnumerable<>` result.

## Sample Output ##
```
Using int++ index
First Pass
1       one
2       two
3       three
4       four
5       five
6       six
7       seven
8       eight
9       nine
10      ten

Second Pass
11      one
12      two
13      three
14      four
15      five
16      six
17      seven
18      eight
19      nine
20      ten

Using int++ index with .ToList()
First Pass
1       one
2       two
3       three
4       four
5       five
6       six
7       seven
8       eight
9       nine
10      ten

Second Pass
1       one
2       two
3       three
4       four
5       five
6       six
7       seven
8       eight
9       nine
10      ten

Using Linq Index
First Pass
1       one
2       two
3       three
4       four
5       five
6       six
7       seven
8       eight
9       nine
10      ten

Second Pass
1       one
2       two
3       three
4       four
5       five
6       six
7       seven
8       eight
9       nine
10      ten

```
