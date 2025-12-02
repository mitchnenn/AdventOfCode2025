// See https://aka.ms/new-console-template for more information

using Common;

var path = "sample_input.txt";
//var path = "input.txt";

var ranges = path.ReadAllText()
    .Split(new[] {',', '\n'}, StringSplitOptions.RemoveEmptyEntries)
    .Select(l => l.Split('-'))
    .Select(parts => (int.Parse(parts[0]),int.Parse(parts[1])))
    .ToList();
ranges.ForEach((l) => Console.WriteLine($"{l.Item1}-{l.Item2}"));

// Part 1
var result1 = SolvePart1(ranges);
Console.WriteLine($"Part 1: {result1}");

// Part 2
var result2 = SolvePart2(ranges);
Console.WriteLine($"Part 2: {result2}");

static int SolvePart1(IEnumerable<(int,int)> input) 
{ 
    return 0; 
}

static int SolvePart2(IEnumerable<(int,int)> input) 
{ 
    return 0; 
}
