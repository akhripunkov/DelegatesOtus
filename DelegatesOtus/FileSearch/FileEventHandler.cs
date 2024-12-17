using DelegatesOtus.Abstractions;

namespace DelegatesOtus.FileSearch;

public class FileEventHandler
{
    private readonly FileSearcher _fileSearcher;
    private readonly string? _cancelledFileName;
    private readonly ILogger _logger;

    public FileEventHandler(FileSearcher fileSearcher,ILogger logger, string? cancelledFileName = null)
    {
        _fileSearcher = fileSearcher;
        _cancelledFileName = cancelledFileName;
        _logger = logger;
        _fileSearcher.FileFound += OnFileFound;
        _fileSearcher.SearchCompleted += OnSearchCompleted;
    }

    private void OnFileFound(object? sender, FileArgs e)
    {
        _logger.Log($"FileFound: {e.FilePath}");

        if (e.FilePath.EndsWith(_cancelledFileName))
        {
            _logger.Log("Cancelled");
            _fileSearcher.Cancel();
            Detach();
        }
    }

    private void OnSearchCompleted(object? sender, EventArgs e)
    {
        _logger.Log("Search completed");
        Detach();
    }
    
    private void Detach()
    {
        _fileSearcher.FileFound -= OnFileFound;
        _fileSearcher.SearchCompleted -= OnSearchCompleted;
    }
}