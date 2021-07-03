using System.CommandLine;
using System.IO;

namespace Example.Cli.Config 
{
    public interface IConfig
    {
        public string CommandName { get;  }
        public string DescriptionText { get;  }

        public Argument<FileInfo> InputFile { get; }
    }
}
