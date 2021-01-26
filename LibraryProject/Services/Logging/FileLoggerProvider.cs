using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace LibraryProject.Services.Logging
{
    public class FileLoggerProvider : ILoggerProvider
    {
        public string path;

        public FileLoggerProvider(string _path)
        {
            path = _path;
        }


        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path);
        }

        public void Dispose()
        {
            
        }
    }
}
