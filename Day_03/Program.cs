// Boilerplate structure.

using Common;

var path = "sample_input.txt";
//var path = "input.txt";

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
    var len = 2;
    foreach (var item in input)
    {
        var digits = item.Select(c => c - '0').ToArray();
        var firstMax = digits[..^(len-1)].Max();
        var secondMax= digits[(Array.IndexOf(digits, firstMax) + 1)..].Max();
        var max = firstMax * 10 + secondMax;
        Console.WriteLine(max);
        sum += max;
    }
    return sum;
}

static ulong SolvePart2(string[] input)
{
    var sum = 0UL;
    const int len = 12;
    foreach (var item in input)
    {
        var jolts = 0UL;
        var bank = item.Select(c => c - '0').Select(i => (ulong)i).ToArray();
        for (var i = 0; i < len - 1; i++)
        {
            var digit = bank[..^(len - 1 - i)].Max();
            bank = bank[(Array.IndexOf(bank, digit) + 1)..];
            jolts  = jolts * 10 + digit; 
        }
        jolts = jolts * 10 + bank.Max();
        Console.WriteLine(jolts);
        sum += jolts;
    }
    return sum;
}


