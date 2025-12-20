// Boilerplate structure.

using Common;

//var path = "sample_input.txt";
var path = "input.txt";

var banks = path.ReadAllLines();
banks.ToList().ForEach(Console.WriteLine);

// Part 1
var result1 = SolvePart1(banks);
Console.WriteLine($"Part 1: {result1}");

// Part 2
var result2 = SolvePart2(banks);
Console.WriteLine($"Part 2: {result2}");

static int SolvePart1(string[] input)
{
    var sum = 0;
    var len = 1;
    foreach (var item in input)
    {
        var digits = item.Select(c => c - '0').ToArray();
        var firstMax = digits[..^len].Max();
        var secondMax= digits[(Array.IndexOf(digits, firstMax) + 1)..].Max();
        sum += firstMax * 10 + secondMax;
    }
    return sum;
}

static ulong SolvePart2(string[] input)
{
    const int len = 12;
    var sum = 0UL;
    foreach (var item in input)
    {
        sum += SolveForMax(item, len);
    }
    return sum;
}

static ulong SolveForMax(string bank, int len)
{
    var digits = bank.Select(c => c - '0').ToArray();
    
    return 0UL;
}

