using Microsoft.Extensions.Logging;
using System;

namespace Example.Cli.Logging
{
    public class ExampleDiagnosticLogger : IDiagnosticLogger
    {
        private readonly ILogger logger;

        public ExampleDiagnosticLogger(ILogger logger)
        {
            this.logger = logger;
            this.ErrorCount = 0;
            this.WarningCount = 0;
        }

        public void LogDiagnostic(Uri fileUri, IDiagnostic diagnostic)
        {
            // build a a code description link if the Uri is assigned
            var codeDescription = diagnostic.Uri == null ? string.Empty : $" [{diagnostic.Uri.AbsoluteUri}]";

            var message = $"[{fileUri.LocalPath}] : {diagnostic.Level} {diagnostic.Code}: {diagnostic.Message}{codeDescription}";

            this.logger.Log(ToLogLevel(diagnostic.Level), message);

            // Increment counters
            if (diagnostic.Level == DiagnosticLevel.Warning) { this.WarningCount++; }
            if (diagnostic.Level == DiagnosticLevel.Error) { this.ErrorCount++; }
        }

        public void LogSummary() 
        {
            var summary = $"Build {(this.ErrorCount > 0 ? "failed" : "succeeded")}: {this.WarningCount} Warning(s), {this.ErrorCount} Error(s)";
            
            this.logger.Log(ToLogLevel(DiagnosticLevel.Warning), summary);
        }

        public int ErrorCount { get; private set; }
        
        private int WarningCount { get; set; }

        private static LogLevel ToLogLevel(DiagnosticLevel level)
            => level switch
            {
                DiagnosticLevel.Info => LogLevel.Information,
                DiagnosticLevel.Warning => LogLevel.Warning,
                DiagnosticLevel.Error => LogLevel.Error,
                _ => throw new ArgumentException($"Unrecognized level {level}"),
            };

    }
}
