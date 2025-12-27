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
    var freshRanges = AllFreshRanges(input)
        .OrderBy(range => range.Minimum)
        .ToList();
    (ulong Minimum, ulong Maximum) last = default;
    foreach (var (lo,hi) in freshRanges)
    {
        if (last == default)
        {
            last = (lo,hi);
        }
        else if (last.Maximum < lo)
        {
            count += last.Maximum - last.Minimum + 1;
            last = (lo,hi);
        }
        else
        {
            last = (last.Minimum, Math.Max(last.Maximum, hi));
        }
    }
    count += last.Maximum - last.Minimum + 1;
    return count;
}

static IEnumerable<ulong> GetIngredientIds(string[] input)
{
    return input
        .SkipWhile(x => x.Contains('-') || string.IsNullOrWhiteSpace(x))
        .Select(ulong.Parse);
}

static IEnumerable<(ulong Minimum, ulong Maximum)> AllFreshRanges(string[] input)
{
    return input
        .TakeWhile(x => !string.IsNullOrEmpty(x))
        .Select(i => i.Split('-'))
        .Select(s => (ulong.Parse(s[0]), ulong.Parse(s[1])))
        .OrderBy(x => x.Item1);
}

