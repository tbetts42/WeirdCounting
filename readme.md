# Weird Counting Test Project #

This program was to test a bug we encountered with how
row numbers were being added to each line read from a CSV file.

Every time the list was accessed, the numbers would jump.

The solution was to use the Linq `.Select((item, index))` method.

A second solution was to add a `.ToList()` to the `IEnumerable<>` result.