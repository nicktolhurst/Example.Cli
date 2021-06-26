using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.CommandLine.Invocation;
using System.CommandLine.IO;

namespace Example.Cli.Commands 
{
    public class DecompileCommandHandler : ICommandHandler
    {
        private readonly ILogger<DecompileCommandHandler> logger;

        public DecompileCommandHandler(ILogger<DecompileCommandHandler> logger)
        {
            this.logger = logger;
        } 

        public Task<int> InvokeAsync(InvocationContext context)
        {
            context.Console.Out.WriteLine($"Invoking: build command!");

            this.logger.LogInformation("Invoking: build command!");

            context.Console.Out.Write($"{nameof(BuildCommandHandler)} was executed successfully!");

            return Task.FromResult(0);
        }
    }
}
