using System.IO;

namespace Task2.WatchService
{
    public interface IWatchService
    {
        void Subscribe(FileSystemEventHandler? onCreated);
    }
}