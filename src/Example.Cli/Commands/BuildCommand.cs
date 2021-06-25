using System.CommandLine;
using System.IO;
using Example.Cli.Helpers;
using Example.Cli.Config;
using Example.Cli.Services;

namespace Example.Cli.Commands 
{
    public class BuildCommand : Command
    {
        public BuildCommand(BuildConfig config) : base(config.CommandName, config.DescriptionText)
        {
            config.Options.ForEach(opt => this.AddOption(opt));
            config.Arguments.ForEach(arg => this.AddArgument(arg));

            this.WithHandler(nameof(HandleCommand));
        }

        private static int HandleCommand(bool stdout, FileInfo outputFile, DirectoryInfo outputDir, bool noSummary, FileInfo file)
        {
            try
            {
                if (!file.Exists)
                {
                    throw new FileNotFoundException($"Could not find file: {file.FullName}");
                }

                if (stdout)
                {
                    return new BuildService().Run(noSummary, file);
                }
                else if (outputFile is not null)
                {
                    return new BuildService().Run(outputFile, noSummary, file);
                }
                else if (outputDir is not null)
                {
                    return new BuildService().Run(outputDir, noSummary, file);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                return 1;
            }

            return 0;
        }
    }
}
