using System;
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

            logger.LogError("Starting Decompile Service");
        }

        public int Run(FileInfo file)
        {
            Console.WriteLine($"\tWriting to stdout. \n\tDecompile file '{file.Name}'.");
            return 0;
        }

        public int Run(FileInfo outputFile, FileInfo file)
        {
            Console.WriteLine($"\tWriting to file: '{outputFile.Name}'. \n\tDecompile file: '{file.Name}'.");
            return 0;
        }

        public int Run(DirectoryInfo outputDir,  FileInfo file)
        {
            Console.WriteLine($"\tWriting to directory: '{outputDir.Name}'. \n\tDecompile file '{file.Name}'.");
            return 0;
        }
    }
}
