using System;
using Example.Cli.Args;

namespace Example.Cli.Commands
{
    public class BuildCommand : CommandBase
    {
        private readonly BuildArgs _args;
        public BuildCommand(BuildArgs args) : base(args)
        {
            _args = args;
        }

        protected override int ToFile(string path)
        {
            Console.WriteLine($"\n To file logic... \n\tPATH: {path}");

            return 0;
        }

        protected override int ToStdout()
        {
            Console.WriteLine($"\n To stdout logic... \n\t ......");

            return 0;
        }
    }
}