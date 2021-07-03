#nullable enable

using System;

namespace Example.Cli.Logging
{
    public interface IDiagnostic 
    {
        string Code { get; }
        DiagnosticLevel Level { get; }
        string Message { get; }
        Uri? Uri { get; }
    }
}
