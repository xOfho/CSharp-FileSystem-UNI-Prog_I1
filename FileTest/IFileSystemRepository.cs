namespace FileTest
{
    public interface IFileSystemRepository
    {
        string[] GetDirectories();
        bool FileExists();
        string ReadFile();
        string GetFileInformation();
    }
}