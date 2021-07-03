using Example.Cli.Logging;
using System.Collections.Generic;

namespace Example.Cli
{
    public class FakeDiagnostics
    {
        public FakeDiagnostics()
        {
            Diagnostics = new List<Diagnostic>
            {
                new Diagnostic(DiagnosticLevel.Error, "3134", "his was an fatal error with code 3134.", new System.Uri("https://www.google.com/")),
                new Diagnostic(DiagnosticLevel.Info, "0", "Some information..."),
                new Diagnostic(DiagnosticLevel.Info, "0", "Some information..."),
                new Diagnostic(DiagnosticLevel.Warning, "0", "This is your last warning! D:", new System.Uri("https://www.google.com/")),
                new Diagnostic(DiagnosticLevel.Warning, "0", "You've been warned...", new System.Uri("https://www.google.com/")),
                new Diagnostic(DiagnosticLevel.Error, "1234", "This was an fatal error with code 1234."),
                new Diagnostic(DiagnosticLevel.Error, "1234", "This was an fatal error with code 1234."),
                new Diagnostic(DiagnosticLevel.Warning, "0", "I'm warning you!!", new System.Uri("https://www.google.com/")),
                new Diagnostic(DiagnosticLevel.Warning, "3134", "This is your last warning! D:"),
            };
        }
        public List<Diagnostic> Diagnostics { get; private set; }
    }
}