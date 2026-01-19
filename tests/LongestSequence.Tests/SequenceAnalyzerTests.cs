using LongestSequence.Core;
using Xunit;

namespace LongestSequence.Tests;

public class SequenceAnalyzerTests
{
    [Theory]
    [InlineData("6 1 5 9 2", "1 5 9")]
    [InlineData("10 20 30 5 15", "10 20 30")] // First longest logic check
    [InlineData("5 1 2 3 4 0 6 7 8 9", "0 6 7 8 9")] // Second longer logic check
    [InlineData("6 2 4 6 1 5 9 2", "2 4 6")] // Test Case 1 from scratchpad/problem? Wait, problem Test Case 1 is 6 1 5 9 2 -> 1 5 9.
    // Let's add the specific Test Cases from the prompt description.
    
    // Test Case 1 from problem
    // Test Case 1 from problem (duplicate removed) 
    
    // Random other examples
    [InlineData("1 2 3", "1 2 3")]
    [InlineData("3 2 1", "3")] // strict increasing, single elements are length 1. 3 is first.
    [InlineData("1", "1")]
    [InlineData("", "")]
    [InlineData("   ", "")]
    [InlineData("10 10 10", "10")] // strictly increasing means 10, 10 is not valid.
    public void FindLongestIncreasingSequence_ReturnsExpectedResult(string input, string expected)
    {
        // Act
        string result = SequenceAnalyzer.FindLongestIncreasingSequence(input);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void FindLongestIncreasingSequence_TestCase2_Sample()
    {
        // Sample distinct logic test (Test Case 10 from problem description says: 6 2 4 6 1 5 9 2 -> 2 4 6)
        // Note: 2 4 6 length 3. 1 5 9 length 3. Earliest is 2 4 6.
        string input = "6 2 4 6 1 5 9 2";
        string expected = "2 4 6";
        string result = SequenceAnalyzer.FindLongestIncreasingSequence(input);
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void FindLongestIncreasingSequence_TestCase11_Sample()
    {
        // Test Case 11 from problem: 6 2 4 3 1 5 9 -> 1 5 9
        // 2 4 (len 2)
        // 3 (len 1)
        // 1 5 9 (len 3)
        string input = "6 2 4 3 1 5 9";
        string expected = "1 5 9";
        string result = SequenceAnalyzer.FindLongestIncreasingSequence(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindLongestIncreasingSequence_HandlesManyIntegers()
    {
        // Construct a large input
        // 1 2 3 (len 3), 1 2 3 4 (len 4)
        string input = "100 1 2 3 50 1 2 3 4 50";
        string expected = "1 2 3 4 50";
        string result = SequenceAnalyzer.FindLongestIncreasingSequence(input);
        Assert.Equal(expected, result);
    }
}
