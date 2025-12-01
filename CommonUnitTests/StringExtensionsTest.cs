using Common;

namespace CommonUnitTests;

public class StringExtensionsTest
{
    [Theory]
    [InlineData("TestData/numbers.txt")]
    public void ParseNumbersTest(string path)
    {
        // Arrange.
        var lines = path.ReadAllLines();
        // Act.
        var numbers = lines.ParseNumbers();
        // Assert.
        Assert.Equal(new[] { 1, 3, 5, 7, 9 }, numbers);
    }
    
    [Theory]
    [InlineData("TestData/number_pairs.txt")]
    public void ParsePairsTest(string path)
    {
        // Arrange.
        var lines = path.ReadAllLines();
        // Act.
        var pairs = lines.ParsePairs();
        // Assert.
        Assert.Equal(
            new[]
            {
                new[] { 1, 2 }, 
                new[] { 3, 4 }, 
                new[] { 5, 6 },
                new[] { 7, 8 },
                new[] { 9, 10 }
            }, 
            pairs);
    }
}