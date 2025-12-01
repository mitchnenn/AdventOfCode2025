using System;
using System.Linq;

namespace Common;

public static class StringExtensions
{
    public static int[] ParseNumbers(this string[] lines)
    {
        return lines.Select(int.Parse).ToArray();
    }

    public static int[][] ParsePairs(this string[] lines)
    {
        return lines.Select(l => 
                l.Split(',')
                    .Select(int.Parse)
                    .ToArray())
            .ToArray();
    }

    public static string[] ParseWords(this string input)
    {
        return input.Split([',', '\n'], StringSplitOptions.RemoveEmptyEntries);
    }
}