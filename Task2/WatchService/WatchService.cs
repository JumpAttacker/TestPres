using System;
using System.IO;

namespace Task2.WatchService
{
    public class WatchService : IWatchService
    {
        public void Subscribe(FileSystemEventHandler? onCreated)
        {
            FileSystemWatcher watcher = new();
            watcher.Path = Directory.GetCurrentDirectory();
            watcher.NotifyFilter = NotifyFilters.Attributes
                                   | NotifyFilters.CreationTime
                                   | NotifyFilters.DirectoryName
                                   | NotifyFilters.FileName
                                   | NotifyFilters.LastAccess
                                   | NotifyFilters.LastWrite
                                   | NotifyFilters.Security
                                   | NotifyFilters.Size;
            watcher.Filter = "*.*";
            watcher.Created += onCreated;
            watcher.EnableRaisingEvents = true;
            Console.WriteLine($"Следим за папкой: {watcher.Path}");
        }
    }
}