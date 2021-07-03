using Microsoft.Extensions.Logging;

namespace Example.Cli.Logging
{
    /// <summary>
    /// Logger provider for writing log entries in an msbuild compatible format.
    /// </summary>
    public class ExampleLoggerProvider : ILoggerProvider
    {
        private readonly ExampleLoggerOptions options;

        public ExampleLoggerProvider(ExampleLoggerOptions options)
        {
            this.options = options;
        }

        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ExampleConsoleLogger(this.options);
        }
    }
}

