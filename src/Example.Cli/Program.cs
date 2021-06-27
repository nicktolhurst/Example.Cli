using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Example.Cli.Helpers;
using Example.Cli.Logging;
using System.CommandLine.Hosting;
using Microsoft.Extensions.Hosting;

namespace Example.Cli
{
    internal class Program
    {
        private readonly RunContext runContext;
        public Program(RunContext runContext)
        {
            this.runContext = runContext;
        }

        public static async Task<int> Main(string[] args)
        {
            RunContext runContext = new RunContext();

            var program = new Program(runContext);

            return await program.Run(args);
        }

        public async Task<int> Run(string[] args)
        {
            ServiceProvider serviceProvider = ConfigureServices();

            ILoggerProvider loggerProvider = GetLoggerProvider();

            Parser parser = BuildCommandLine(serviceProvider, loggerProvider);

            return await parser.InvokeAsync(args).ConfigureAwait(false);
        }

        private Parser BuildCommandLine(ServiceProvider serviceProvider, ILoggerProvider loggerProvider)
        {
            // Configure the commandline
            var commandLineBuilder = new CommandLineBuilder()
                .UseDefaults()
                .UseMiddleware(context => context.BindingContext.AddService(_ => serviceProvider))
                .UseHost(host => host
                    .ConfigureServices(services => services
                        .AddCliCommandConfig()
                        .AddSingleton(runContext)
                        .AddCommandLineHandlers()));

            // Add the commands from the DI container
            foreach (var command in serviceProvider.GetServices<Command>())
            {
                commandLineBuilder.AddCommand(command);
            }

            return commandLineBuilder.Build();
        }

        private ILoggerProvider GetLoggerProvider()
        {
            return new ExampleLoggerProvider(new ExampleLoggerOptions(true, ConsoleColor.Red, ConsoleColor.DarkYellow, this.runContext.ErrorWriter));
        }

        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddCliCommandConfig()
                .AddCliCommands()
                .AddLogging(configure => configure
                    .ClearProviders()
                    .AddProvider(GetLoggerProvider()))
                .BuildServiceProvider();
        }
    }
}