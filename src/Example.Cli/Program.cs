using System;
using System.Text.RegularExpressions;
using Example.Cli.Args;
using Example.Cli.Commands;

namespace Example.Cli
{
    class Program
    {
        static int Main(string[] args) => new Program().Run(args);

        private int Run(string[] args)
        {
            try
            {
                switch (ArgsParser.TryParse(args))
                {
                    case Args.LintArgs a when a.CommandName == Constants.Commands.Lint:         // example lint file.rst
                        return new LintCommand(a).Run(); 

                    case Args.BuildArgs a when a.CommandName == Constants.Commands.Build:           // example run file.rst
                        return new BuildCommand(a).Run(); 

                    case Args.DecompileArgs a when a.CommandName == Constants.Commands.Decompile:   // example version
                        return new DecompileCommand(a).Run(); 
                                                                                                // Root command and top level arguments
                    case Args.RootArgs a when a.CommandName == null ||                          // example 
                        new Regex(Constants.Args.VersionRgx).IsMatch(args[0]) ||                // example --version || example -v
                        new Regex(Constants.Args.HelpRgx).IsMatch(args[0]):                     // example --help || example -h
                            return new RootCommand(a).Run();

                    default:
                        Console.Error.WriteLine($"Unrecognised args: '{String.Join("', '",args)}'");
                        return 1;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}
