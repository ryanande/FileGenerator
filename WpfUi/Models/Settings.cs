using System;
using SimpleMvvmToolkit;
using FileGenerator.Core;

namespace FileGenerator.WpfUi
{
    public class Settings : ModelBase<Settings>
    {
        private string _outputPath;
        public string OutputPath
        {
            get { return _outputPath; }
            set
            {
                _outputPath = value;
                NotifyPropertyChanged(m => m.OutputPath);
            }
        }

        private int _totalFiles;
        public int TotalFiles
        {
            get { return _totalFiles; }
            set
            {
                _totalFiles = value;
                NotifyPropertyChanged(m => m.TotalFiles);
            }
        }

        private string _prefix;
        public string Prefix
        {
            get { return _prefix; }
            set
            {
                _prefix = value;
                NotifyPropertyChanged(m => m.Prefix);
            }
        }

        private string _extension;
        public string Extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
                NotifyPropertyChanged(m => m.Extension);
            }
        }


        private int _fileSize;
        public int FileSize
        {
            get { return _fileSize; }
            set
            {
                _fileSize = value;
                NotifyPropertyChanged(m => m.FileSize);
            }
        }        

        private FileNamingType _selectedFileNamingType;
        public FileNamingType SelectedFileNamingType
        {
            get { return _selectedFileNamingType; }
            set
            {
                _selectedFileNamingType = value;
                NotifyPropertyChanged(m => m.SelectedFileNamingType);
            }
        }

        private bool _openExplorer;
        public bool OpenExplorer
        {
            get { return _openExplorer; }
            set
            {
                _openExplorer = value;
                NotifyPropertyChanged(m => m.OpenExplorer);
            }
        }

    }
}
