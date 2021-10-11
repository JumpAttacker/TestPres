using System;
using System.IO;
using System.Linq;

namespace Task2.Executor
{
    public class OthersFileExecutor : IFileExecutor
    {
        public string Execute(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден по пути {path}");
            }
            string readText = File.ReadAllText(path);
            var countOfPunctuations = readText.Count(char.IsPunctuation);
            Console.WriteLine($"Кол-во знаков препинания: = {countOfPunctuations}");
            return countOfPunctuations.ToString();
        }
    }
}