// Boilerplate structure.

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

static int SolvePart1(string[] input)
{
    var grid = GridExtensions.ReadGrid(input);
    var paperIndexes = grid.SelectMany((row, r) => row
        .Select((ch, c) => new { ch, r, c })
        .Where(x => x.ch == '@')
        .Select(x => (x.r, x.c)))
        .ToList();
    return AccessCount(grid, paperIndexes).AccessCount;
}

static int SolvePart2(string[] input) 
{
    var grid = GridExtensions.ReadGrid(input);
    var paperIndexes = grid.SelectMany((row, r) => row
            .Select((ch, c) => new { ch, r, c })
            .Where(x => x.ch == '@')
            .Select(x => (x.r, x.c)))
        .ToList();
    var totalAccessCount = 0;
    while (true)
    {
        var (accessCount, removed) = AccessCount(grid, paperIndexes);
        if (removed.Count == 0)  break;
        totalAccessCount += accessCount;
        paperIndexes.RemoveAll(x => removed.Contains(x));
    }
    
    return totalAccessCount; 
}

static (int AccessCount, List<(int, int)> Removed) AccessCount(
    char[][] grid, 
    List<(int r, int c)> paperIndexes)
{
    var maxAccessCount = 4;
    var accessCount = 0;
    var removed = new List<(int, int)>();
    foreach (var paperIndex in paperIndexes)
    {
        var adjacentCount = 0;
        for (var rowIndex = paperIndex.r - 1; rowIndex <= paperIndex.r + 1; rowIndex++)
        {
            for (var colIndex = paperIndex.c - 1; colIndex <= paperIndex.c + 1; colIndex++)
            {
                if (!grid.InBounds(rowIndex, colIndex)) continue;
                if(rowIndex == paperIndex.r && colIndex == paperIndex.c) continue;
                if (paperIndexes.Contains((rowIndex, colIndex)))
                {
                    adjacentCount++;
                }
            }
        }
        if(adjacentCount < maxAccessCount)
        {
            accessCount++;
            removed.Add((paperIndex.r, paperIndex.c));
        }
    }

    return (accessCount, removed);
}