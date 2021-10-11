namespace Task2.Printer
{
    public interface IResultPrinter
    {
        void Print(string result, ActionEnum fileCreate, string name);
    }
}