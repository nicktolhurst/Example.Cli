using System;
using System.IO;

namespace Example.Cli
{
    public class RunContext
    {
        public TextWriter OutputWriter { get; set; } = Console.Out;
        public TextWriter ErrorWriter { get; set; } = Console.Error;
        public string AssemblyFileVersion { get; set; } = ThisAssembly.AssemblyFileVersion;
    }
}
