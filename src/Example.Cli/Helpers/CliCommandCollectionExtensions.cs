using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using Example.Cli.Commands;
using Example.Cli.Config;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Cli.Helpers
{

    /// <summary>
    /// Contains the collection extensions for adding the CLI commands.
    /// </summary>
    public static class CliCommandCollectionExtensions
    {
        /// <summary>
        /// Adds the CLI commands to the DI container. These are resolved when the commands are registered with the
        /// <c>CommandLineBuilder</c>.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <returns>The service collection, for chaining.</returns>
        /// <remarks>
        /// We are using convention to register the commands; essentially everything in the same namespace as the
        /// <see cref="BuildCommand"/> and that implements <c>Command</c> will be registered. If any commands are
        /// added in other namespaces, this method will need to be modified/extended to deal with that.
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

        public static IServiceCollection AddCliCommandConfig(this IServiceCollection services)
        {
            Type grabConfigType = typeof(BuildConfig);
            Type configType = typeof(IConfig);

            IEnumerable<Type> configs = grabConfigType
                .Assembly
                .GetExportedTypes()
                .Where(x => x.Namespace == grabConfigType.Namespace && x.GetInterfaces().Contains(typeof(IConfig)));

            foreach (Type config in configs)
            {
                services.AddScoped(config);
            }

            return services;
        }
    }
}