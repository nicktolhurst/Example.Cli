using System.Collections.Generic;
using System.CommandLine;

namespace Example.Cli.Config 
{
    public interface IConfig
    {
        public string CommandName { get; set; }
        public string DescriptionText { get; set; }
        public List<Option> Options { get; set; }
        public List<Argument> Arguments { get; set; }
    }
}
