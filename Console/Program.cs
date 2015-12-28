using System;
using System.IO;
using CommandLine;

namespace FileGenerator
{
    class Program
    {
        private static string _leading;
        private static string _extension;
        private static int _totalFiles;
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("OuputPath and TotalFiles values must be passed in.");
            }
            else
            {
                ICommandLineParser parser = new CommandLineParser(new CommandLineParserSettings { MutuallyExclusive = false, HelpWriter = Console.Error, CaseSensitive = false });
                var options = new Options();
                if (parser.ParseArguments(args, options))
                {
                    _leading = options.LeadingFileName;
                    _extension = options.Extension;
                    _totalFiles = options.TotalFiles;

                    if (!Directory.Exists(options.OuputPath))
                    {
                        Console.WriteLine(string.Format("Directory does not exist! {0}", options.OuputPath));
                        return;
                    }             

                    var path = options.OuputPath;

                    if (!path.EndsWith("\\"))
                        path += "\\";

                    var engine = new FileGenerator.Core.Engine();
                    engine.Execute(path, _leading, _extension, 100, _totalFiles, Core.FileNamingType.Text);                 
                }                
            }         
        }
    }
}
