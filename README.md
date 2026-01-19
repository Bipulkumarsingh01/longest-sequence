# Longest Increasing Subsequence

This project is a C# .NET solution that finds the longest increasing subsequence from a given string of whitespace-separated integers.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker](https://www.docker.com/products/docker-desktop) (optional, for containerized execution)

## Project Structure

- `src/LongestSequence.ConsoleApp`: The console application entry point.
- `src/LongestSequence.Core`: The core logic library.
- `tests/LongestSequence.Tests`: Unit tests.

## How to Run

### Option 1: Using .NET CLI

You can run the application directly using the .NET CLI.

1.  **Run with arguments:**
    Pass the sequence of numbers as a quoted string argument.

    ```bash
    dotnet run --project src/LongestSequence.ConsoleApp/LongestSequence.ConsoleApp.csproj -- "6 1 5 9 2"
    ```

    **Output:**
    ```
    1 5 9
    ```

### Option 2: Using Docker

1.  **Build the Docker image:**

    ```bash
    docker build -t longest-sequence .
    ```

2.  **Run the Docker container:**

    ```bash
    docker run --rm longest-sequence "6 1 5 9 2"
    ```

## How to Test

Run the unit tests to verify the solution:

```bash
dotnet test
```
