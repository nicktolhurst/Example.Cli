using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Example.Cli.Config;

namespace Example.Cli.Helpers
{
    /// <summary>
    /// Contains the collection extensions supporting the invocation of a command.
    /// </summary>
    public static class InvocationExtensions
    {
        public static Command HandleWith<T>(this Command command) where T : ICommandHandler
        {
            command.Handler = CommandHandler.Create<IHost, InvocationContext>((host, invocation) =>
            {
                return host.Services.GetRequiredService<T>().InvokeAsync(invocation);
            });

            return command;
        }

        public static Command AddSymbolsFromConfig<T>(this Command command, T config) where T : IConfig
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (typeof(IOption).IsAssignableFrom(property.PropertyType))
                {
                    command.AddOption((Option)property.GetValue(config, null));
                }
                if (typeof(IArgument).IsAssignableFrom(property.PropertyType))
                {
                    command.AddArgument((Argument)property.GetValue(config, null));
                }
            }

            return command;
        }

        // Hacky workaround for ValueForOption(IOption) returning null..
        public static T GetValueFor<T>(this InvocationContext context, Option<T> option)
        {
            return context.ParseResult.ValueForOption<T>(option.Aliases.First());
        }

        // Hacky workaround for ValueForArgument(IArgument) returning null..
        public static T GetValueFor<T>(this InvocationContext context, Argument<T> argument)
        {
            return context.ParseResult.ValueForArgument<T>(argument.Name);
        }

        // Adds extension method for validator for method chaining.
        public static Command ValidateWith(this Command command, ValidateSymbol<CommandResult> validate)
        {
            command.AddValidator(validate);

            return command;
        }
    }
}