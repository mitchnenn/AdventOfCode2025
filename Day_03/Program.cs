// Boilerplate structure.

using Common;

var path = "sample_input.txt";
//var path = "input.txt";

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
    return 0; 
}

static int SolvePart2(string[] input) 
{ 
    return 0; 
}