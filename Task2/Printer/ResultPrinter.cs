using System;
using System.IO;

namespace Task2.Printer
{
    public class ResultPrinter : IResultPrinter
    {
        public void Print(string result, ActionEnum fileCreate, string name)
        {
            string path = @$"e:\{name}-{fileCreate.ToString()}-{result}";
            if (File.Exists(path))
            {
                File.Delete(path);
            };
            using StreamWriter sw = File.CreateText(path);
            sw.WriteLine($"Результат операции: {result}");
            sw.Close();
            Console.WriteLine($"Файл успешно создан по пути: {path}");
        }
    }
}