using System;

namespace Example.Cli.Logging
{
    public interface IDiagnosticLogger
    {
        void LogDiagnostic(Uri fileUri, IDiagnostic diagnostic);
        void LogSummary();
        
    }
}

