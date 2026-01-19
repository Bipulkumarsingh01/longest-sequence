using LongestSequence.Core;

namespace LongestSequence.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // Support piping input or interactive mode
        // If input is provided via args (though problem says "takes one string input", usually stdin for coding tests)
        // or just read from Console.ReadLine
        
        string? input = null;

        // If arguments are provided, join them, otherwise try reading from stdin
        if (args.Length > 0)
        {
            input = string.Join(" ", args);
        }
        else
        {
            // Read from standard input (useful for piping or manual entry)
            // We read all text to support multi-line if needed, but problem implies "a sequence".
            // However, coding tests often pipe files.
            // Let's read strictly one line or all lines? Problem says "takes one string input".
            // We'll read the full content from Input to handle the format <line>
            
            // Check if input is redirected
            if (Console.IsInputRedirected)
            {
               input = Console.In.ReadToEnd();
            }
            else
            {
                // Interactive mode prompt
                Console.WriteLine("Enter the sequence of integers separated by single whitespace:");
                input = Console.ReadLine();
            }
        }

        if (input == null) return;

        try
        {
            string result = SequenceAnalyzer.FindLongestIncreasingSequence(input);
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
