using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSequence.Core;

public static class SequenceAnalyzer
{
    /// <summary>
    /// Parses a string of space-separated integers and returns the longest contiguous strictly increasing subsequence.
    /// If multiple sequences have the same maximum length, the earliest one is returned.
    /// </summary>
    /// <param name="input">Space-separated integers string.</param>
    /// <returns>The longest increasing subsequence as a string.</returns>
    public static string FindLongestIncreasingSequence(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
        {
            return string.Empty;
        }

        int[] numbers;
        try
        {
            numbers = parts.Select(int.Parse).ToArray();
        }
        catch (FormatException)
        {
            // Requirement says "input of any number of integers". 
            // If parsing fails, we could throw or return empty. Stick to throwing for invalid input format context
            // or return strictly what we parsed? Let's assume valid integers as per problem description.
            throw new ArgumentException("Input string contains non-integer values.");
        }

        if (numbers.Length == 0) return string.Empty;

        // Variables to track the best sequence found so far
        int bestStart = 0;
        int bestLength = 1;

        // Variables to track the current sequence
        int currentStart = 0;
        int currentLength = 1;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                currentLength++;
            }
            else
            {
                // check if the current sequence is the longest
                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                    bestStart = currentStart;
                }

                // reset current sequence
                currentStart = i;
                currentLength = 1;
            }
        }

        // Final check for the sequence ending at the last element
        if (currentLength > bestLength)
        {
            bestLength = currentLength;
            bestStart = currentStart;
        }

        // Extract the subarray
        var longestSubsequence = numbers.Skip(bestStart).Take(bestLength);
        
        return string.Join(" ", longestSubsequence);
    }
}
