using System.CommandLine;
using System.Linq;

using Example.Cli.Handlers;
using Example.Cli.Helpers;
using Example.Cli.Config;

namespace Example.Cli.Commands 
{
    public class BuildCommand : Command
    {
        public BuildCommand(BuildConfig config) : base(config.CommandName, config.DescriptionText)
        {
            this.AddSymbolsFromConfig(config)
                .HandleWith<BuildCommandHandler>()
                .ValidateWith(r => 
                {
                    var outdir = r.Children.Contains(config.OutputDirectory.Aliases.First());
                    var stdout = r.Children.Contains(config.Stdout.Aliases.First());
                    var outfile = r.Children.Contains(config.OutputFile.Aliases.First()); 

                    if (outdir && stdout)
                    {
                        return $"Options '--output-dir' and '--stdout' cannot be used together.";
                    }

                    if (outdir && outfile)
                    {
                        return $"Options '--output-dir' and '--output-file' cannot be used together.";
                    }

                    if (stdout && outfile)
                    {
                        return $"Options '--stdout' and '--output-file' cannot be used together.";
                    }

                    return null;
                });
        } 
    }
}
