using System;
using System.IO;
using Task2.Executor;
using Task2.Printer;
using Task2.WatchService;

namespace Task2
{
    public class Engine
    {
        public Engine()
        {
            Console.WriteLine("Starting...");
            
            Watcher = new WatchService.WatchService();
            ResultPrinter = new ResultPrinter();
            
            Watcher.Subscribe(OnFileCreated);
        }
        
        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Добавлен файл: {e.Name}");
            var name = e.Name!;
            IFileExecutor fileExecutor = name switch
            {
                _ when name.EndsWith(".html") => new HtmlFileExecutor(),
                _ when name.EndsWith(".css") => new CssFileExecutor(),
                _ => new OthersFileExecutor()
            };

            var result = fileExecutor.Execute(e.FullPath);
            ResultPrinter.Print(result, ActionEnum.FileCreate, Path.GetFileNameWithoutExtension(e.FullPath));
        }

        private IWatchService Watcher { get; }
        private IResultPrinter ResultPrinter { get; }
    }
}