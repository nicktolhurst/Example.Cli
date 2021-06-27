using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Example.Cli.Config;
using Example.Cli.Helpers;

namespace Example.Cli.Handlers 
{
    public class BuildCommandHandler : ICommandHandler
    {
        private readonly ILogger<BuildCommandHandler> logger;
        private readonly BuildConfig config;
        private readonly RunContext runContext;

        public BuildCommandHandler(ILogger<BuildCommandHandler> logger, BuildConfig config, RunContext runContext)
        {
            this.logger = logger;
            this.config = config;
            this.runContext = runContext;
        } 

        public Task<int> InvokeAsync(InvocationContext context)
        {
            bool isNoSummary = context.GetValueFor(config.NoSummary);
            bool isStdOut = context.GetValueFor(config.Stdout);
            FileInfo outputFile = context.GetValueFor(config.OutputFile);
            DirectoryInfo outputDirectory = context.GetValueFor(config.OutputDirectory);


            if(outputFile is not null)
            {
                if(outputFile.Directory.Exists)
                {
                    if(outputFile.Exists)
                    {
                        runContext.ErrorWriter.WriteLine($"File exists: {outputFile.FullName}. Let's not overwrite it!");
                        return Task.FromResult(1);
                    }

                    WriteFile(outputFile);
                }
            }
            else if(outputDirectory is not null)
            {
                WriteFile(outputDirectory);
            }
            else if (isStdOut)
            {
                PrintStdout();
            }
            else
            {
                runContext.OutputWriter.WriteLine($"Else....");
            }

            if (!isNoSummary)
            {
                PrintSummary();
            }

            return Task.FromResult(0);
        }

        private void PrintSummary()
        {
            runContext.OutputWriter.WriteLine($"Summary text! Version info: {runContext.AssemblyFileVersion}");   
        }

        private void PrintStdout()
        {
            runContext.OutputWriter.WriteLine($"Printing results to stdout...");
        }

        private void WriteFile(FileInfo file)
        {
            runContext.OutputWriter.WriteLine($"Printing results to file '{file.FullName}'...");
        }

        private void WriteFile(DirectoryInfo directoryInfo)
        {
            runContext.OutputWriter.WriteLine($"Printing results to directory '{directoryInfo.FullName}'...");
        }
    }
}
