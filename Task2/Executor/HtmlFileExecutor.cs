using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2.Executor
{
    public class HtmlFileExecutor : IFileExecutor
    {
        public string Execute(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден по пути {path}");
            }
            string readText = File.ReadAllText(path);
            string pattern = @"\<div";
            const RegexOptions options = RegexOptions.Multiline;
            var matches = Regex.Matches(readText, pattern, options);
            Console.WriteLine($"Кол-во символов div: {matches.Count}");
            return matches.Count.ToString();
        }
    }
}