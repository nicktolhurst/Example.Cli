using System;
using Example.Cli.Args;

namespace Example.Cli.Commands
{
    public abstract class CommandBase
    {
        private readonly ArgsBase _args;

        public CommandBase(ArgsBase args)
        {
            _args = args;
        }

        public virtual int Run()
        {
            Console.WriteLine($"COMMAND: example {_args.CommandName}... ");
            
            return !String.IsNullOrEmpty(_args.OutputFile) ? ToFile(_args.OutputFile) :
                   !String.IsNullOrEmpty(_args.OutputDirectory) ? ToFile(_args.OutputDirectory + "/file.txt") :
                   _args.ToStdout ? ToStdout() :
                   ToFile("defaultpath/file.txt");
        }

        protected abstract int ToFile(string file);

        protected abstract int ToStdout();
    }
}