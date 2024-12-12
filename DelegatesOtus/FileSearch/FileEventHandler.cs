namespace DelegatesOtus.FileSearch;

public class FileEventHandler
{
    private readonly FileSearcher _fileSearcher;

    public FileEventHandler(FileSearcher fileSearcher)
    {
        _fileSearcher = fileSearcher;
        _fileSearcher.FileFound += OnFileFound;
        _fileSearcher.SearchCompleted += OnSearchCompleted;
    }

    private void OnFileFound(object? sender, FileArgs e)
    {
        Console.WriteLine($"FileFound: {e.FilePath}");

        if (e.FilePath.EndsWith("cancelled.txt"))
        {
            Console.WriteLine("Cancelled");
            _fileSearcher.Cancel();
        }
    }

    private void OnSearchCompleted(object? sender, EventArgs e)
    {
        Console.WriteLine("Search completed");
    }
    
}