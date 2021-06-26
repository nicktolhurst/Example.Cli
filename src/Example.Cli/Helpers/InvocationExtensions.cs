using System.CommandLine;
using System.CommandLine.Invocation;
using System.Reflection;

namespace Example.Cli.Helpers
{
    /// <summary>
    /// Contains the collection extensions supporting the invocation of a command.
    /// </summary>
    public static class InvocationExtensions
    {
        /// <summary>
        /// Uses reflection to grab the method info for the <see cref="ICommandHandler"/>.
        /// </summary>
        /// <param name="command">The cli command that this handler is being assigned to.</param>
        /// <param name="name">The name of the method in the command class that is used as the handler.</param>
        /// <returns>The command class.</returns>
        /// <remarks>
        /// The handler class parameters should match the configuration of the cli command options & arguments. See this
        /// model binding guide for more information: https://github.com/dotnet/command-line-api/blob/main/docs/model-binding.md
        /// 
        /// We are using this generic method-first approach to simplify implementation. See Figure 5 in 
        /// https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/march/net-parse-the-command-line-with-system-commandline
        /// </remarks>
        public static T WithHandler<T>(this T command, string name) where T : Command
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var method = typeof(T).GetMethod(name, flags);

            var handler = CommandHandler.Create(method!);
            command.Handler = handler;
            return command;
        }
    }
}