// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using Common;

//var path = "sample_input.txt";
var path = "input.txt";

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
        validIds.AddRange(ProcessRange(start, end, ValidId1));
    return validIds.Count != 0 ? validIds.Sum() : 0L; 
}

static IEnumerable<long> ProcessRange(string start, string end, Func<string, bool> isValid)
{
    // None of the numbers have leading zeroes;
    // 0101 isn't an ID at all. (101 is a valid ID that you would ignore.)
    if(start.StartsWith('0') || end.StartsWith('0')) yield break;
    for (var id = long.Parse(start); id <= long.Parse(end); id++)
        if (!isValid(id.ToString())) yield return id;
}

static bool ValidId1(string id)
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

static long SolvePart2(IEnumerable<(string,string)> input) 
{ 
    var validIds = new List<long>();
    foreach (var (start, end) in input)
        validIds.AddRange(ProcessRange(start, end, ValidId2));
    validIds.ForEach(Console.WriteLine);
    return validIds.Count != 0 ? validIds.Sum() : 0L; 
}

static bool ValidId2(string id)
{
    if (id.Length <= 1) return true;
    
    // All the same:
    if (1 == id.ToCharArray().Distinct().ToHashSet().Count) return false;
    
    // Has repeated strings greater than 1 character long?.
    if (IsStringOfDuplicates(id)) return false;
    
    return true;
}

static bool IsStringOfDuplicates(string id)
{
    var maxDuplicateLength = id.Length / 2;
    for (var l = maxDuplicateLength; l >= 2; l--)
    {
        var possibleDuplicate = id.Substring(0, l);
        var splits = id.Split(possibleDuplicate, StringSplitOptions.None);
        if(splits.Distinct().Count() == 1)
            return true;
    }
    return false;
}
