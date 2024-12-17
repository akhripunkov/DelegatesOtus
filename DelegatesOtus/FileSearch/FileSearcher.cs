using DelegatesOtus.Abstractions;

namespace DelegatesOtus.FileSearch;

public class FileSearcher
{
    public event EventHandler<FileArgs> FileFound;
    public event EventHandler SearchCompleted;
    
    private bool _cancelled;
    private ILogger _logger;

    public FileSearcher(ILogger logger)
    {
        _logger = logger;
    }

    public void SearchFiles(string directory)
    {
        _cancelled = false;
        try
        {
            foreach (var filePath in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
            {
                if (_cancelled)
                    break;

                OnFileFound(new FileArgs(filePath));
            }
        }
        finally
        {
            OnSearchCompleted(EventArgs.Empty);
        }
    }
    
    protected virtual void OnFileFound(FileArgs e)
    {
        FileFound?.Invoke(this, e);
    }
    
    protected virtual void OnSearchCompleted(EventArgs e)
    {
        SearchCompleted?.Invoke(this, e);
    }
    
    public void Cancel()
    {
        Console.WriteLine("Cancel request received.");
        _cancelled = true;
    }
}
