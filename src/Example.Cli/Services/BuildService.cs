using System;
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
            logger.LogInformation($"\tWriting to stdout. \n\tBuild file '{file.Name}'. \n\tPrinting summary: '{noSummary == false}'.");

            if(!noSummary)
            {
                logger.LogWarning($"\tExcluding summary!");
            }

            return 0;
        }

        public int Run(FileInfo outputFile, bool noSummary, FileInfo file)
        {
            Console.WriteLine($"\tWriting to file: '{outputFile.Name}'. \n\tBuild file: '{file.Name}'. \n\tPrinting summary: '{noSummary == false}'.");

            if(!noSummary)
            {
                logger.LogWarning($"\tExcluding summary!");
            }

            return 0;
        }

        public int Run(DirectoryInfo outputDir, bool noSummary, FileInfo file)
        {
            Console.WriteLine($"\tWriting to directory: '{outputDir.Name}'. \n\tBuild file '{file.Name}'. \n\tPrinting summary: '{noSummary == false}'.");

            if(!noSummary)
            {
                logger.LogWarning($"\tExcluding summary!");
            }

            return 0;
        }
    }
}
