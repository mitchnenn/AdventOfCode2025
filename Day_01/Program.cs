// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
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
    int result = 0;
    const int maxStep = 99;
    int currentStep = 50;
    foreach (var combo in input)
    {
        int steps = ParseComboTurn(combo);
        currentStep = Turn(currentStep, maxStep, steps);
        if(currentStep == 0) result++;
    }
    return result;
}

static int SolvePart2(string[] input)
{
    int result = 0;
    const int maxStep = 99;
    int currentStep = 50;
    foreach (var combo in input)
    {
        int steps = ParseComboTurn(combo);
        (currentStep, var zeroCout) = TurnAndCountZero(currentStep, maxStep, steps);
        result += zeroCout;
    }
    return result;
}

static int ParseComboTurn(string turn)
{
    var regex = new Regex(@"^([LR])(\d+)$", RegexOptions.Compiled);
    var match = regex.Match(turn.ToUpper());
    if (!match.Success) throw new Exception();
    var direction = match.Groups[1].Value[0];
    var steps = int.Parse(match.Groups[2].Value);
    return direction == 'R' ? steps : -steps;
}

static int Turn(int currentStep, int maxSteps, int steps)
{
    var newStep = currentStep;
    for (var i = 0; i < Math.Abs(steps); i++)
    {
        newStep = steps < 0 ? newStep - 1 : newStep + 1;
        if (newStep < 0) newStep = maxSteps;
        else if (newStep > maxSteps) newStep = 0;
    }
    return newStep;
}

static (int, int) TurnAndCountZero(int currentStep, int maxSteps, int steps)
{
    var newStep = currentStep;
    var zeroCount = 0;
    for (var i = 0; i < Math.Abs(steps); i++)
    {
        newStep = steps < 0 ? newStep - 1 : newStep + 1;
        if (newStep < 0) newStep = maxSteps;
        else if (newStep > maxSteps) newStep = 0;
        if (newStep == 0) zeroCount++;
    }
    return (newStep, zeroCount);
}