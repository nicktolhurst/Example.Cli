using System.CommandLine;
using System.Reflection;
using Example.Cli.Helpers;
using Example.Cli.Config;

namespace Example.Cli.Commands 
{
    public class BuildCommand : Command
    {
        public BuildCommand(BuildConfig config) : base(config.CommandName, config.DescriptionText)
        {
            this.AddSymbolsFromConfig(config)
                .HandleWith<BuildCommandHandler>();
        } 
    }
}
