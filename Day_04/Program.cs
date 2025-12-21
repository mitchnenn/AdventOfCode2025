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
    var maxAccessCount = 4;
    var grid = GridExtensions.ReadGrid(input);
    var paperIndexes = grid.SelectMany((row, r) => row
        .Select((ch, c) => new { ch, r, c })
        .Where(x => x.ch == '@')
        .Select(x => (x.r, x.c)))
        .ToList();
    var accessCount = 0;
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
        }
    }
    return accessCount; 
}

static int SolvePart2(string[] input) 
{ 
    return 0; 
}