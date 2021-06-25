using System;
using System.IO;

namespace Example.Cli.Services 
{
    public class BuildService
    {
        public BuildService()
        {
        }

        public int Run(bool noSummary, FileInfo file)
        {
            Console.WriteLine($"\tWriting to stdout. \n\tBuild file '{file.Name}'. \n\tPrinting summary: '{noSummary == false}'.");
            return 0;
        }

        public int Run(FileInfo outputFile, bool noSummary, FileInfo file)
        {
            Console.WriteLine($"\tWriting to file: '{outputFile.Name}'. \n\tBuild file: '{file.Name}'. \n\tPrinting summary: '{noSummary == false}'.");
            return 0;
        }

        public int Run(DirectoryInfo outputDir, bool noSummary, FileInfo file)
        {
            Console.WriteLine($"\tWriting to directory: '{outputDir.Name}'. \n\tBuild file '{file.Name}'. \n\tPrinting summary: '{noSummary == false}'.");
            return 0;
        }
    }
}
