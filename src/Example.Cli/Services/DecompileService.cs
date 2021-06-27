using System.IO;

using Microsoft.Extensions.Logging;

namespace Example.Cli.Services 
{
    public class DecompileService
    {
        private readonly ILogger logger;

        public DecompileService(ILogger logger)
        {
            this.logger = logger;
        }

        public int Run(FileInfo file)
        {
            return 0;
        }

        public int Run(FileInfo outputFile, FileInfo file)
        {
            return 0;
        }

        public int Run(DirectoryInfo outputDir,  FileInfo file)
        {
            return 0;
        }
    }
}
