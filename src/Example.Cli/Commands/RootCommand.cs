using System;
using Example.Cli.Args;

namespace Example.Cli.Commands
{
    public class RootCommand 
    {
        private readonly RootArgs _args;
        public RootCommand(RootArgs args) 
        {
            _args = args;
        }

        public int Run()
        {
            if (_args.PrintHelp) 
            {
                Console.Out.WriteLine("Help Text!");
                return 0;
            }
            else if (_args.PrintVersion)
            {
                Console.Out.WriteLine("Print Version!");
                return 0;
            }
            else 
            {
                Console.Out.WriteLine("Help Text!"); 
                return 0;
            }
        }
    }
}