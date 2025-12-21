namespace Common;

public static class GridExtensions
{
    public static char[][] ReadGrid(string[] input)
    {
        return input
            .Select(l => l.ToCharArray())
            .ToArray();
    }
    
    public static bool InBounds(this char[][] grid, int r, int c) 
    {
        return r >= 0 && r < grid.Length && c >= 0 && c < grid[0].Length;
    }
}