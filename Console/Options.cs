
using CommandLine;

namespace FileGenerator
{
    public class Options : CommandLineOptionsBase
    {
        [Option("o", "output", Required = true, HelpText = "Output")]
        public string OuputPath { get; set; }
        [Option("c", "count", Required = true, HelpText = "count", DefaultValue = 1)]
        public int TotalFiles { get; set; }
        [Option("p", "prefix", Required = false, HelpText = "prefix", DefaultValue = "")]
        public string LeadingFileName { get; set; }
        [Option("e", "extension", Required = false, HelpText = "Extension", DefaultValue = "txt")]
        public string Extension { get; set; }

        //[HelpOption]
        //public string GetUsage()
        //{
        //    // this without using CommandLine.Text
        //    var usage = new StringBuilder();
        //    usage.AppendLine("FileGenerator 1.0");
        //    usage.AppendLine("-output is the directory where you wish the generated files generated.");
        //    usage.AppendLine("-files total number of files to create..");
        //    usage.AppendLine("The below example created 10000 files to the C:\\TestFiles directory.");
        //    usage.AppendLine("FileGenerator -output \"C:\\TestFiles\" -files 10000 ");
        //    return usage.ToString();
        //}
    }
}
