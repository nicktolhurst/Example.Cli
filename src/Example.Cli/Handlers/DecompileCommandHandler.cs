using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Example.Cli.Config;
using Example.Cli.Helpers;

namespace Example.Cli.Handlers 
{
    public class DecompileHandler : ICommandHandler
    {
        private readonly ILogger<BuildCommandHandler> logger;
        private readonly DecompileConfig config;
        private readonly RunContext runContext;

        public DecompileHandler(ILogger<BuildCommandHandler> logger, DecompileConfig config, RunContext runContext)
        {
            this.logger = logger;
            this.config = config;
            this.runContext = runContext;
        } 

        public Task<int> InvokeAsync(InvocationContext context)
        {
            throw new System.NotImplementedException();
        }

        private void PrintStdout()
        {
            throw new System.NotImplementedException();
        }

        private void WriteFile(FileInfo file)
        {
            throw new System.NotImplementedException();
        }

        private void WriteFile(DirectoryInfo directoryInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
