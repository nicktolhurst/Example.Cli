using System.Text.RegularExpressions;

namespace Example.Cli.Args
{
    public class RootArgs : ArgsBase
    {
        public RootArgs()
        {
            PrintHelp = true;
        }

        public RootArgs(string arg) : base()
        {
            switch(arg)
            {
                case var a when new Regex(Constants.Args.VersionRgx).IsMatch(a):
                    PrintVersion = true;
                    break;
                    
                case var a when new Regex(Constants.Args.HelpRgx).IsMatch(a):
                    PrintHelp = true;
                    break;
            };
        }

        new public bool PrintHelp { get; private set; }

        public bool PrintVersion { get; private set; }
    }
}
