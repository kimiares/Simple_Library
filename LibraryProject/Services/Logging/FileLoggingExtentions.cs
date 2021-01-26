using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace LibraryProject.Services.Logging
{
    public static class FileLoggingExtentions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
