// Boilerplate structure.

using System.Diagnostics;
using Common;

//var path = "sample_input.txt";
var path = "input.txt";

var lines = path.ReadAllLines();
lines.ToList().ForEach(Console.WriteLine);

// Part 1
var result1 = SolvePart1(lines);
Console.WriteLine($"Part 1: {result1}");

// Part 2
var result2 = SolvePart2(lines);
Console.WriteLine($"Part 2: {result2}");

static long SolvePart1(string[] input)
{
    var count = 0L;
    foreach (var operaton in ParseInput(input))
    {
        var numbers = operaton.Operands.Select(long.Parse);
        switch (operaton.Operation)
        {
            case "+":
                count += numbers.Aggregate((a, b) => a + b);
                break;
            case "*":
                count += numbers.Aggregate((a, b) => a * b);
                break;
            default:
                Debug.Assert(false, $"Unknown operation: {operaton.Operation}");
                break;
        }
    }
    return count; 
}

static IEnumerable<(IEnumerable<string> Operands, string Operation)> ParseInput(string[] input)
{
    var rows = input
        .Select(l => l.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries))
        .ToList();
    var dataRows = rows.SkipLast(1).ToList();
    var colCount = dataRows[0].Length;
    var operands = Enumerable.Range(0, colCount)
        .Select(colIndex => dataRows.Select(r => r[colIndex]).ToList())
        .ToList();
    Debug.Assert(operands.Count == rows.Last().Length, "Number of columns doesn't match operations");
    foreach (var (index, column) in operands.Index())
    {
        yield return (column, rows.Last()[index]);
    }
}

static int SolvePart2(string[] input) 
{ 
    return 0; 
}

