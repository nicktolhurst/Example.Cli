using System;
using System.CommandLine;
using System.Collections.Generic;
using System.CommandLine.Invocation;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Example.Cli.Commands;
using Example.Cli.Config;
using Example.Cli.Handlers;

namespace Example.Cli.Helpers
{

    /// <summary>
    /// Contains the collection extensions for adding the CLI commands and configuration of those commands.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the CLI commands to the DI container. These are resolved when the commands are registered with the
        /// <c>CommandLineBuilder</c>.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <returns>The service collection, for chaining.</returns>
        /// <remarks>
        /// We are using convention to register the commands; essentially everything in the same namespace as the
        /// <see cref="BuildCommand"/> and that implements <c>Command</c> will be registered. 
        ///
        /// See https://endjin.com/blog/2020/09/simple-pattern-for-using-system-commandline-with-dependency-injection for reference.
        /// </remarks>
        public static IServiceCollection AddCliCommands(this IServiceCollection services)
        {
            Type grabCommandType = typeof(BuildCommand);
            Type commandType = typeof(Command);

            IEnumerable<Type> commands = grabCommandType
                .Assembly
                .GetExportedTypes()
                .Where(x => x.Namespace == grabCommandType.Namespace && commandType.IsAssignableFrom(x));

            foreach (Type command in commands)
            {
                services.AddSingleton(commandType, command);
            }

            return services;
        }

        /// <summary>
        /// Adds the corresponding configuration, used by the commands, to the DI container. These are resolved when the commands are registered with the
        /// <c>CommandLineBuilder</c>.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <returns>The service collection, for chaining.</returns>
        /// <remarks>
        /// We are using convention to register these configurations; essentially everything in the same namespace as the
        /// <see cref="BuildConfig"/> and that implements <c>IConfig</c> will be registered. 
        ///
        /// See https://endjin.com/blog/2020/09/simple-pattern-for-using-system-commandline-with-dependency-injection for reference.
        /// </remarks>
        public static IServiceCollection AddCliCommandConfig(this IServiceCollection services)
        {
            Type grabConfigType = typeof(BuildConfig);
            Type configType = typeof(IConfig);

            IEnumerable<Type> configs = grabConfigType
                .Assembly
                .GetExportedTypes()
                .Where(x => x.Namespace == grabConfigType.Namespace && x.GetInterfaces().Contains(configType));

            foreach (Type config in configs)
            {
                services.AddSingleton(config);
            }

            return services;
        }

        public static IServiceCollection AddCommandLineHandlers(this IServiceCollection services)
        {
            Type grabConfigType = typeof(BuildCommandHandler);
            Type configType = typeof(ICommandHandler);

            IEnumerable<Type> configs = grabConfigType
                .Assembly
                .GetExportedTypes()
                .Where(x => x.Namespace == grabConfigType.Namespace && x.GetInterfaces().Contains(configType));

            foreach (Type config in configs)
            {
                services.AddSingleton(config);
            }

            return services;
        }
    }
}