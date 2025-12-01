using Common;

namespace CommonUnitTests;

public class FileExtensionTests
{
    [Theory]
    [InlineData("TestData/input.txt")]
    public void ReadAllLinesTest(string path)
    {
        // Arrange.
        // Act.
        var lines = path.ReadAllLines();
        // Assert.
        Assert.Equal(3, lines.Length);
    }

    [Theory]
    [InlineData("TestData/input.txt")]
    public void ReadAllTextTest(string path)
    {
        // Arrange.
        // Act.
        var text = path.ReadAllText();
        // Assert.
        Assert.Equal("line 1.\nline 2.\nline 3.", text);
    }
}