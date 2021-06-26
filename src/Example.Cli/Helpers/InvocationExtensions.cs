using System.CommandLine;
using System.CommandLine.Invocation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Example.Cli.Helpers
{
    /// <summary>
    /// Contains the collection extensions supporting the invocation of a command.
    /// </summary>
    public static class InvocationExtensions
    {
        public static Command HandledBy<T>(this Command command) where T : ICommandHandler
        {
            command.Handler = CommandHandler.Create<IHost, InvocationContext>((host, invocation) =>
            {
                var logger = host.Services.GetService<ILogger<T>>();

                logger.LogWarning($"Executing service: {nameof(T)}");

                return host.Services.GetRequiredService<T>().InvokeAsync(invocation);
            });
            return command;
        }
    }
}