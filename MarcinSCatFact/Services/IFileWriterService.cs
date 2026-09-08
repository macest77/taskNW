using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinSCatFact.Services
{
    internal interface IFileWriterService
    {
        string EnsureFileExists();

        Task AppendLineAsync(string line, CancellationToken cancellationToken = default);
    }
}
