using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Example.Cli.Helpers;

namespace Example.Cli
{
    internal static class Program
    {
        public static async Task<int> Main(string[] args)
        {
            ServiceProvider serviceProvider = BuildServiceProvider();
            Parser parser = BuildParser(serviceProvider);

            return await parser.InvokeAsync(args).ConfigureAwait(false);
        }

        private static Parser BuildParser(ServiceProvider serviceProvider)
        {
            var commandLineBuilder = new CommandLineBuilder();

            foreach (Command command in serviceProvider.GetServices<Command>())
            {
                commandLineBuilder.AddCommand(command);
            }

            return commandLineBuilder.UseDefaults().Build();
        }

        private static ServiceProvider BuildServiceProvider() 
            => new ServiceCollection()
                .AddCliCommands()
                .AddCliCommandConfig()
                .BuildServiceProvider();
    }
}
