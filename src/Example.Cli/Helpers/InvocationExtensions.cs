using System.CommandLine;
using System.CommandLine.Invocation;
using System.Reflection;

namespace Example.Cli.Helpers
{
    public static class InvocationExtensions
    {
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