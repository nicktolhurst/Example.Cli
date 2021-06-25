using System.Collections.Generic;
using System.CommandLine;
using System.IO;

namespace Example.Cli.Config 
{
    public class BuildConfig : IConfig
    {
        public BuildConfig()
        {
            this.CommandName = "build";

            this.DescriptionText = "This is the descriptie text for the build command.";

            this.Options = new List<Option>()
            {
                new Option<bool>("--stdout")
                {
                    Description = "Print out to the console.",
                    IsRequired = false,
                },
                new Option<FileInfo>("--output-file")
                {
                    Description = "Write out to a specified file.",
                    IsRequired = false,
                },
                new Option<DirectoryInfo>("--output-dir")
                {
                    Description = "Write out to a specified directory.",
                    IsRequired = false,
                },
                new Option<bool>("--no-summary")
                {
                    Description = "Omits summary from stdout",
                    IsRequired = false,
                },
            };

            this.Arguments = new List<Argument>()
            {
                new Argument
                {
                    Name = "file",
                    Description = "The file to build.",
                    ArgumentType = typeof(FileInfo)
                }
            };
        }

        public string CommandName { get; set; }
        public string DescriptionText { get; set; }
        public List<Option> Options { get; set; }
        public List<Argument> Arguments { get; set; }
    }
}
