# Palindrome Number Filtering: Sequential and Parallel Approaches

Beginner level task for practicing features of the Task Parallel Library.

Estimated time to complete the task - 1h.

The task requires .NET 6 SDK installed.

## Task Description

Implement a `Selector` static class  that contains methods for filtering palindrome numbers from a collection of integers. The class provides two different approaches for filtering palindrome numbers: sequential filtering and parallel filtering.

The `Selector` class has the following methods:

- `GetPalindromeInSequence(IList<int> numbers)`: This method retrieves a collection of palindrome numbers from the given list of integers using sequential filtering. It takes a list of integers as input and returns a collection of palindrome numbers as the output. The method utilizes the private `IsPalindrome(int number)` method to determine whether a number is a palindrome or not.

- `GetPalindromeInParallel(IList<int> numbers)`: This method retrieves a collection of palindrome numbers from the given list of integers using parallel filtering. It takes a list of integers as input and returns a collection of palindrome numbers as the output. The method utilizes parallel processing with `Parallel.ForEach` to filter palindrome numbers concurrently. It also uses the private `IsPalindrome(int number)` method to check whether a number is a palindrome.

The `Selector` class contains several private helper methods:
- `IsPalindrome(int number)`: This private method checks whether the given integer is a palindrome number. It first verifies that the number is non-negative and then uses the `IsPositiveNumberPalindrome(int number, int divider)` method to perform a recursive check on positive numbers.
- `IsPositiveNumberPalindrome(int number, int divider)`: This private method recursively checks whether a positive number is a palindrome. It compares the first digit with the last digit and proceeds with the check by removing these digits from the number until the number becomes less than 10.
- `GetLength(int number)`: This private method calculates the number of digits in the given integer. It uses a switch statement to handle different ranges of numbers efficiently.

To get insights into the benefits of parallel processing when dealing with computationally intensive tasks like filtering palindrome numbers from a large collection of integers compare the efficiency of the two approaches in terms of performance. 
