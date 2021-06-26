using System.CommandLine;
using Example.Cli.Helpers;
using Example.Cli.Config;

namespace Example.Cli.Commands 
{
    public class DecompileCommand : Command
    {
        public DecompileCommand(DecompileConfig config) : base(config.CommandName, config.DescriptionText)
        {
            config.Options.ForEach(opt => this.AddOption(opt));
            config.Arguments.ForEach(arg => this.AddArgument(arg));

            this.HandledBy<DecompileCommandHandler>();
        } 
    }
}
