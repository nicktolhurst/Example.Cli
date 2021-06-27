using System.IO;

using Microsoft.Extensions.Logging;

namespace Example.Cli.Services 
{
    public class BuildService
    {
        private readonly ILogger logger; 

        public BuildService(ILogger logger)
        {
            this.logger = logger;
        }

        public int Run(bool noSummary, FileInfo file)
        {
            return 0;
        }

        public int Run(FileInfo outputFile, bool noSummary, FileInfo file)
        {
            return 0;
        }

        public int Run(DirectoryInfo outputDir, bool noSummary, FileInfo file)
        {
            return 0;
        }
    }
}
