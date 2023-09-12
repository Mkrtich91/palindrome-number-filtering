using System.Collections.Concurrent;
using System.Globalization;

namespace PalindromeNumberFiltering;

/// <summary>
/// A static class containing methods for filtering palindrome numbers from a collection of integers.
/// </summary>
public static class Selector
{
    /// <summary>
    /// Retrieves a collection of palindrome numbers from the given list of integers using sequential filtering.
    /// </summary>
    /// <param name="numbers">The list of integers to filter.</param>
    /// <returns>A collection of palindrome numbers.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input list 'numbers' is null.</exception>
    public static IList<int> GetPalindromeInSequence(IList<int>? numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers), "The input list 'numbers' cannot be null.");
        }

        IList<int> palindromeNumbers = new List<int>();
        foreach (var number in from int number in numbers
                               where IsPalindrome(number)
                               select number)
        {
            palindromeNumbers.Add(number);
        }

        return palindromeNumbers;
    }

    /// <summary>
    /// Retrieves a collection of palindrome numbers from the given list of integers using parallel filtering.
    /// </summary>
    /// <param name="numbers">The list of integers to filter.</param>
    /// <returns>A collection of palindrome numbers.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input list 'numbers' is null.</exception>
    public static IList<int> GetPalindromeInParallel(IList<int> numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers), "The input list 'numbers' cannot be null.");
        }

        var palindromeNumbers = new ConcurrentBag<int>();

        _ = Parallel.ForEach(numbers, number =>
        {
            if (IsPalindrome(number))
            {
                palindromeNumbers.Add(number);
            }
        });

        return palindromeNumbers.ToList();
    }

    /// <summary>
    /// Checks whether the given integer is a palindrome number.
    /// </summary>
    /// <param name="number">The integer to check.</param>
    /// <returns>True if the number is a palindrome, otherwise false.</returns>
    private static bool IsPalindrome(int number)
    {
        string numStr = number.ToString(CultureInfo.InvariantCulture);

        int left = 0;
        int right = numStr.Length - 1;

        while (left < right)
        {
            if (numStr[left] != numStr[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    /// <summary>
    /// Recursively checks whether a positive number is a palindrome.
    /// </summary>
    /// <param name="number">The positive number to check.</param>
    /// <param name="divider">The divider used in the recursive check.</param>
    /// <returns>True if the positive number is a palindrome, otherwise false.</returns>
    private static bool IsPositiveNumberPalindrome(int number, int divider)
    {
        if (number < 10)
        {
            return true;
        }

        int leftDigit = number / divider;

        int rightDigit = number % 10;

        if (leftDigit != rightDigit)
        {
            return false;
        }

#pragma warning disable IDE0047
        int remainingNumber = (number % divider) / 10;
#pragma warning restore IDE0047

        int newDivider = divider / 100;

        return IsPositiveNumberPalindrome(remainingNumber, newDivider);
    }

    /// <summary>
    /// Gets the number of digits in the given integer.
    /// </summary>
    /// <param name="number">The integer to count digits for.</param>
    /// <returns>The number of digits in the integer.</returns>
#pragma warning disable IDE0051
#pragma warning disable S1144
    private static byte GetLength(int number)
#pragma warning restore S1144
#pragma warning restore IDE0051
    {
        number = Math.Abs(number);

        if (number == 0)
        {
            return 1;
        }

        byte length = 0;

        length += number switch
        {
            >= 1000000000 => 10,
            >= 100000000 => 9,
            >= 10000000 => 8,
            >= 1000000 => 7,
            >= 100000 => 6,
            >= 10000 => 5,
            >= 1000 => 4,
            >= 100 => 3,
            >= 10 => 2,
            _ => 1,
        };
        return length;
    }
}
