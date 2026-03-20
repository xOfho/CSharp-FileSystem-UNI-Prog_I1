using System;
using System.IO;

namespace FileTest
{
    public class FileSystemRepository : IFileSystemRepository
    {
        private string _path;

        public FileSystemRepository(string path)
        {
            _path = path;
        }

        public bool FileExists()
        {
            return File.Exists(_path);
        }

        public string[] GetDirectories()
        {
            return Directory.GetDirectories(_path);
        }

        public string GetFileInformation()
        {
            if (File.Exists(_path) || Directory.Exists(_path))
            {
                string info = $"{_path} existe\n";

                info += $"Creación: {File.GetCreationTime(_path)}\n";
                info += $"Última modificación: {File.GetLastWriteTime(_path)}\n";
                info += $"Último acceso: {File.GetLastAccessTime(_path)}\n";

                return info;
            }
            else
            {
                return null;
            }
        }

        public string ReadFile()
        {
            try
            {
                return File.ReadAllText(_path);
            }
            catch (IOException)
            {
                return null;
            }
        }
    }
}
