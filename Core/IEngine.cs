using System;

namespace FileGenerator.Core
{
    public interface IEngine
    {
        string OutputPath { get; set; }
        string Prefix { get; set; }
        string Extension { get; set; }
        int FileSize { get; set; }
        int Count { get; set; }
        FileNamingType FileNaming { get; set; }

        void Execute(string outputPath, string prefix, string extension, int fileSize, int count, FileNamingType fileNaming);
        void GenerateFile();
        string BuildContent(int length);
    }
}
