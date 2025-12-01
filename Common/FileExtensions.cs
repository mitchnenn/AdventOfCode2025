using System.IO;

namespace Common;

public static class FileExtensions
{
   public static string[] ReadAllLines(this string path)
   {
      return File.ReadAllLines(path);
   }

   public static string ReadAllText(this string path)
   {
      return File.ReadAllText(path).Trim();
   }
}
