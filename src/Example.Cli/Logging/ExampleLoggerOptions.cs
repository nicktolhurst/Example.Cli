// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.IO;

namespace Example.Cli.Logging
{
    public class ExampleLoggerOptions
    {
        public ExampleLoggerOptions(bool enableColors, ConsoleColor errorColor, ConsoleColor warningColor, TextWriter writer)
        {
            this.EnableColors = enableColors;
            this.ErrorColor = errorColor;
            this.WarningColor = warningColor;
            this.Writer = writer;
        }

        public bool EnableColors { get; set; }

        public ConsoleColor ErrorColor { get; set; }

        public ConsoleColor WarningColor { get; set; }

        public TextWriter Writer { get; set; }
    }
}
