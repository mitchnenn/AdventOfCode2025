// See https://aka.ms/new-console-template for more information

using Common;

var path = "sample_input.txt";
//var path = "input.txt";

var ranges = path.ReadAllText()
    .Split(new[] {',', '\n'}, StringSplitOptions.RemoveEmptyEntries)
    .Select(l => l.Split('-'))
    .Select(parts => (Start: parts[0], End: parts[1]))
    .ToList();
ranges.ForEach((l) => Console.WriteLine($"{l.Item1}-{l.Item2}"));

// Part 1
var result1 = SolvePart1(ranges);
Console.WriteLine($"Part 1: {result1}");

// Part 2
var result2 = SolvePart2(ranges);
Console.WriteLine($"Part 2: {result2}");

static long SolvePart1(IEnumerable<(string,string)> input)
{
    var validIds = new List<Int64>();
    foreach (var (start, end) in input)
        validIds.AddRange(ProcessRange(start, end));
    return validIds.Count != 0 ? validIds.Sum() : 0L; 
}

static IEnumerable<long> ProcessRange(string start, string end)
{
    // None of the numbers have leading zeroes;
    // 0101 isn't an ID at all. (101 is a valid ID that you would ignore.)
    if(start.StartsWith('0') || end.StartsWith('0')) yield break;
    for (var id = long.Parse(start); id <= long.Parse(end); id++)
        if (!ValidId(id.ToString())) yield return id;
}

static bool ValidId(string id)
{
    if(id.Length % 2 != 0) return true; // Odd length IDs are always valid.
    // Sequence of digits repeated twice.
    // So, 55 (5 twice), 6464 (64 twice), and 123123 (123 twice)
    // would all be invalid IDs
    var halfLength = id.Length / 2;
    var firstHalf = id.Substring(0, halfLength);
    var secondHalf = id.Substring(halfLength, halfLength);
    return firstHalf != secondHalf;
}

static int SolvePart2(IEnumerable<(string,string)> input) 
{ 
    return 0; 
}
