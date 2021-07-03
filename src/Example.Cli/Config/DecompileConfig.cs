using System.CommandLine;
using System.IO;

namespace Example.Cli.Config 
{
    public class DecompileConfig : IConfig
    {
        public DecompileConfig()
        {
            CommandName = "decompile";

            DescriptionText = "This is the descriptive text for the decompile command.";

            InputFile = new Argument<FileInfo>("file")
            {
                Description = "Input file..",
            };

            Stdout = new Option<bool>("--stdout")
            {
                Name = "--stdout",
                Description = "Print out to the console.",
                IsRequired = false,
            };

            OutputFile = new Option<FileInfo>("--output-file")
            {
                Description = "Write out to a specified file.",
                IsRequired = false,
            };

            OutputDirectory = new Option<DirectoryInfo>("--output-dir")
            {
                Description = "Write out to a specified directory.",
                IsRequired = false,
            };
        }

        public string CommandName { get; }
        public string DescriptionText { get; }
        public Argument<FileInfo> InputFile { get; }
        public Option<bool> Stdout { get; }
        public Option<FileInfo> OutputFile { get; }
        public Option<DirectoryInfo> OutputDirectory { get; }
    }
}
