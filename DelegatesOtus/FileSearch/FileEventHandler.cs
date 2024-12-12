namespace DelegatesOtus.FileSearch;

public class FileEventHandler
{
    private readonly FileSearcher _fileSearcher;
    private readonly string _cancelledFileName;

    public FileEventHandler(FileSearcher fileSearcher, string? cancelledFileName = null)
    {
        _fileSearcher = fileSearcher;
        _cancelledFileName = cancelledFileName;
        _fileSearcher.FileFound += OnFileFound;
        _fileSearcher.SearchCompleted += OnSearchCompleted;
    }

    private void OnFileFound(object? sender, FileArgs e)
    {
        Console.WriteLine($"FileFound: {e.FilePath}");

        if (e.FilePath.EndsWith(_cancelledFileName))
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