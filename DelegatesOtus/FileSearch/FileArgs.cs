namespace DelegatesOtus.FileSearch;

public class FileArgs : EventArgs
{
    public string FilePath { get; init; }

    public FileArgs(string filePath)
    {
        FilePath = filePath;
    }
}