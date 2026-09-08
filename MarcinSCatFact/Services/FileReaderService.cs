using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinSCatFact.Services
{
    internal class FileReaderService : IFileReaderService
    {
        public void ReadFile(IFileWriterService fileWriterService)
        {
            string filePath = fileWriterService.EnsureFileExists();

            if (new FileInfo(filePath).Length == 0)
            {
                Console.WriteLine("Plik jest pusty.");
                return;
            }

            foreach (var line in File.ReadLines(filePath))
            {
                Console.WriteLine(line);
            }
        }
    }
}
