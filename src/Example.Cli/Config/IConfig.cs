using System.Collections.Generic;
using System.CommandLine;

namespace Example.Cli.Config 
{
    public interface IConfig
    {
        public string CommandName { get;  }
        public string DescriptionText { get;  }
    }
}
