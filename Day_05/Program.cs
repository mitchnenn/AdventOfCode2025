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

static ulong SolvePart1(string[] input) 
{
    ulong count = 0;
    foreach (var ingredient in GetIngredientIds(input))
    {
        if (GetFreshRanges(input).Any(fresh => 
                ingredient >= fresh.Minimum 
                && ingredient <= fresh.Maximum))
        {
            count++;
        }
    }
    return count;
}

static int SolvePart2(string[] input) 
{ 
    return 0; 
}

static IEnumerable<(ulong Minimum, ulong Maximum)> GetFreshRanges(string[] input)
{
    return input
        .TakeWhile(x => !string.IsNullOrEmpty(x))
        .Select(i => i.Split('-'))
        .Select(s => (ulong.Parse(s[0]), ulong.Parse(s[1])));
}

static IEnumerable<ulong> GetIngredientIds(string[] input)
{
    return input
        .SkipWhile(x => x.Contains('-') || string.IsNullOrWhiteSpace(x))
        .Select(ulong.Parse)
        .ToList();
}

