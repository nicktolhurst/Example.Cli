#nullable enable
using System.Text.RegularExpressions;

namespace Example.Cli.Args
{
    public static class ArgsParser
    {
        public static ArgsBase? TryParse(string[] args)
        {
            if (args.Length < 1)
            {
                return new RootArgs(); // default root args set's print help to true
            }

            // parse verb
            return (args[0].ToLowerInvariant()) switch
            {
                Constants.Commands.Lint => new LintArgs(args[1..], Constants.Commands.Lint),
                Constants.Commands.Build => new BuildArgs(args[1..], Constants.Commands.Build),
                Constants.Commands.Decompile => new DecompileArgs(Constants.Commands.Decompile),
                var arg when new Regex(Constants.Args.VersionRgx).IsMatch(arg) ||
                             new Regex(Constants.Args.HelpRgx).IsMatch(arg)
                             => new RootArgs(arg),                
                _ => null
            };
        }
    }
}