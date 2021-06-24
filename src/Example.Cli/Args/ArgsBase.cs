using System.Linq;
using System.Text.RegularExpressions;

namespace Example.Cli.Args
{
    public abstract class ArgsBase
    {

        public ArgsBase()
        {
        }
        
        public ArgsBase(string commandName)
        {   
            CommandName = commandName;
        }

        public ArgsBase(string[] args, string commandName)
        {   
            CommandName = commandName;

            PrintHelp = args.Any(x => new Regex(Constants.Args.HelpRgx).IsMatch(x)); // print command specific help if --help appears anywhere in args.

            for (var i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLowerInvariant()) 
                {
                    case "--stdout": 
                        this.ToStdout = true; 
                        break;

                    case "--outdir":
                        this.OutputDirectory = args[i + 1];
                        i++;
                        break;

                    case "--outfile":
                        this.OutputFile = args[i + 1];
                        i++;
                        break;
                }
            }
        }

        public string CommandName { get; }

        public bool PrintHelp { get; }

        public virtual string OutputFile { get; }

        public virtual string OutputDirectory { get; }

        public virtual bool ToStdout { get; }
    }
}