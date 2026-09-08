using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinSCatFact.Services
{
    internal class FileWriterService : IFileWriterService
    {
        private string _fileName;
        private readonly string _directoryPath;
        private string _filePath;

        public FileWriterService(string fileName = "catfacts")
        {
            _fileName = fileName;
            _directoryPath = Path.Combine(AppContext.BaseDirectory, "facts");
            _filePath = Path.Combine(_directoryPath, _fileName + ".txt");
        }

        public void SetFileName(string newFileName)
        {
            _fileName = newFileName;
            _filePath = Path.Combine(_directoryPath, _fileName + ".txt");
        }

        public string EnsureFileExists()
        {
            Directory.CreateDirectory(_directoryPath);

            if (!File.Exists(_filePath))
            {
                using var _ = File.Create(_filePath);
            }

            return _filePath;
        }
    }
}
