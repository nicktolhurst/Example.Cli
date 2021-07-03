#nullable enable

using System;
using System.Diagnostics;

namespace Example.Cli.Logging
{
    // roughly equivalent to the 'SyntaxDiagnosticInfo' class in Roslyn
    [DebuggerDisplay("Level = {" + nameof(Level) + "}, Code = {" + nameof(Code) + "}, Message = {" + nameof(Message) + "}")]
    public class Diagnostic : IDiagnostic
    {
        public Diagnostic(DiagnosticLevel level, string code, string message, Uri? documentationUri = null)
        {
            Level = level;
            Code = code;
            Message = message;
            Uri = documentationUri;
        }

        public DiagnosticLevel Level { get; }

        public string Code { get; }

        public string Message { get; }

        public Uri? Uri { get; }
    }
}
