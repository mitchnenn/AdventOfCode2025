using System.IO;
using System.Linq;

namespace Common;

public static class FileExtensions
{
   public static string[] ReadAllLines(this string path)
   {
      return File.ReadAllLines(path)
         .Select(l => l.Trim())
         .ToArray();
   }

   public static string ReadAllText(this string path)
   {
      return File.ReadAllText(path)
         .Trim();
   }
}
