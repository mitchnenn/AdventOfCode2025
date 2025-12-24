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
    return GetIngredientIds(input)
        .Count(id => AllFreshRanges(input).Any(range => 
                id >= range.Minimum && id <= range.Maximum));
}

static ulong SolvePart2(string[] input)
{
    var count = 0UL;
    foreach (var range in UniqueFreshRanges(input))
    {
        count += range.Maximum - range.Minimum + 1; 
    }
    return count;
}

static IEnumerable<ulong> GetIngredientIds(string[] input)
{
    return input
        .SkipWhile(x => x.Contains('-') || string.IsNullOrWhiteSpace(x))
        .Select(ulong.Parse)
        .ToList();
}

static IEnumerable<(ulong Minimum, ulong Maximum)> AllFreshRanges(string[] input)
{
    return input
        .TakeWhile(x => !string.IsNullOrEmpty(x))
        .Select(i => i.Split('-'))
        .Select(s => (ulong.Parse(s[0]), ulong.Parse(s[1])));
}

static IEnumerable<(ulong Minimum, ulong Maximum)> UniqueFreshRanges(string[] input)
{
    foreach (var ingredientId in GetIngredientIds(input))
    {
        foreach (var range in AllFreshRanges(input))
        {
            if (ingredientId < range.Minimum || ingredientId > range.Maximum) continue;
            yield return range;
        }    
    }
}
