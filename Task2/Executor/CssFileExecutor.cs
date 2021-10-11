using System;
using System.IO;
using System.Linq;

namespace Task2.Executor
{
    public class CssFileExecutor : IFileExecutor
    {
        public string Execute(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден по пути {path}");
            }
            string readText = File.ReadAllText(path);
            var countOfOpenBracket = readText.Count(x => x.Equals('{'));
            var countOfOpenClosed = readText.Count(x => x.Equals('}'));
            var isEquals = countOfOpenBracket.Equals(countOfOpenClosed);
            Console.WriteLine($"Кол-во открывающих скобок совпадает с количеством закрывающих скобок: {countOfOpenBracket}=={countOfOpenClosed} = {isEquals.ToString()}");
            return isEquals.ToString();
        }
    }
}