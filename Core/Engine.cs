using System;
using System.IO;
using System.Text;

namespace FileGenerator.Core
{
    public class Engine : IEngine
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public string OutputPath { get; set; }
        public string Prefix { get; set; }
        public string Extension { get; set; }
        public int FileSize { get; set; }
        public int Count { get; set; }
        public FileNamingType FileNaming { get; set; }

        public void Execute(string outputPath, string prefix, string extension, int fileSize, int count, FileNamingType fileNaming)
        {
            Extension = string.IsNullOrEmpty(extension) ? "txt" : extension;

            if (!Directory.Exists(outputPath))
                throw new DirectoryNotFoundException(outputPath); /// Does this make any sense at all??? lol not...

            OutputPath = outputPath;
            Prefix = prefix;
            FileSize = fileSize == 0 ? 100 : fileSize;
            Count = count == 0 ? 1 : count;
            FileNaming = fileNaming;

            for (var i = 1; i <= Count; i++)
            {
                GenerateFile();
            }
        }

        public void GenerateFile()
        {
            string filePath = GetFullFilePath();
            while (File.Exists(filePath))
                filePath = GetFullFilePath();

            using (TextWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(BuildContent(FileSize));
                writer.Close();
            }
        }

        public string BuildContent(int length)
        {            
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < length; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
           
        public string GetFullFilePath()
        {
            return Path.Combine(OutputPath, string.IsNullOrWhiteSpace(Prefix) ? string.Format("{0}.{1}", GetFileName(), Extension) : string.Format("{0}{1}.{2}", Prefix, GetFileName(), Extension));
        }

        public string GetFileName()
        {
            switch (FileNaming)
            {
                case FileNamingType.Text:
                    return BuildContent(6);
                case FileNamingType.Number:
                    return RandomNumber(1, 50000).ToString();
                case FileNamingType.UniqueIdentifier:
                default:
                    return Guid.NewGuid().ToString();
            }
        }

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
