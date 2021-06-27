using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Example.Cli.Config;
using Example.Cli.Helpers;
using Example.Cli.Logging;

namespace Example.Cli.Handlers 
{
    public class BuildCommandHandler : ICommandHandler
    {
        private readonly ILogger<BuildCommandHandler> logger;
        private readonly IDiagnosticLogger diagnosticLogger;
        private readonly BuildConfig config;
        private readonly RunContext runContext;

        public BuildCommandHandler(ILogger<BuildCommandHandler> logger, BuildConfig config, RunContext runContext)
        {
            this.logger = logger;
            this.config = config;
            this.runContext = runContext;
            this.diagnosticLogger = new ExampleDiagnosticLogger(logger);
        } 

        public Task<int> InvokeAsync(InvocationContext context)
        {
            bool isNoSummary = context.GetValueFor(config.NoSummary);
            bool isStdOut = context.GetValueFor(config.Stdout);
            FileInfo outputFile = context.GetValueFor(config.OutputFile);
            DirectoryInfo outputDirectory = context.GetValueFor(config.OutputDirectory);
            FileInfo inputFile = context.GetValueFor(config.InputFile);
            System.Uri inputUri = new System.Uri(inputFile.FullName);

            if(outputFile is not null)
            {
                WriteFile(inputUri,outputFile);
            }
            else if(outputDirectory is not null)
            {
                WriteFile(inputUri,outputDirectory);
            }
            else if (isStdOut)
            {
                PrintStdout(inputUri);
            }
            else
            {
                logger.LogError("Could not resolve parameters..");
            }

            if (!isNoSummary)
            {
                PrintSummary();
            }

            return Task.FromResult(0);
        }

        private void PrintSummary()
        {
            diagnosticLogger.LogSummary();
        }

        private void PrintStdout(System.Uri inputUri)
        {
            runContext.OutputWriter.WriteLine($"Printing to Stdout : inputUri={inputUri}");

            new FakeDiagnostics().Diagnostics.ForEach(diagnostic => 
                diagnosticLogger.LogDiagnostic(inputUri, diagnostic)); 
        }

        private void WriteFile(System.Uri inputUri, FileInfo outputFile)
        {
            runContext.OutputWriter.WriteLine($"Writing to file : inputUri={inputUri} : outputFile={outputFile}");

            new FakeDiagnostics().Diagnostics.ForEach(diagnostic => 
                diagnosticLogger.LogDiagnostic(inputUri, diagnostic)); 
        }

        private void WriteFile(System.Uri inputUri, DirectoryInfo outputDirectory)
        {
            runContext.OutputWriter.WriteLine($"Writing to directory : inputUrl={inputUri} : outputDirectory={outputDirectory}");

            new FakeDiagnostics().Diagnostics.ForEach(diagnostic => 
                diagnosticLogger.LogDiagnostic(inputUri, diagnostic)); 
        }
    }
}
