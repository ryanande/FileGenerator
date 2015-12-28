using System;
using SimpleMvvmToolkit;
using System.Windows.Input;
using FileGenerator.Core;
using System.Diagnostics;

namespace FileGenerator.WpfUi
{
    public class SettingsViewModel : ViewModelDetailBase<SettingsViewModel, Settings>
    {


        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;
        public event EventHandler<NotificationEventArgs> GenerationStarted;
        public event EventHandler<NotificationEventArgs> GenerateComplete;
        public event EventHandler<NotificationEventArgs> OpenBrowse;
        private readonly IEngine _engine;


        private ICommand _generateCommand;
        public ICommand GenerateCommand
        {
            get
            {
                if (_generateCommand == null)
                    _generateCommand = new AsyncDelegateCommand(Generate, null, (s) => GenerateCompleted(), (ex) => NotifyError(ex.Message, ex));

                return _generateCommand;
            }
        }


        public ICommand BrowseCommand
        {
            get
            {
                return new DelegateCommand(Browse);
            }
        }


        private bool _generating;
        public bool Generating
        {
            get
            {
                return _generating;
            }
            set
            {
                _generating = value;
                NotifyPropertyChanged(m => m.Generating);
            }
        }


        public SettingsViewModel(IEngine engine)
        {
            _engine = engine;
            Model = new Settings { SelectedFileNamingType = FileNamingType.Text, OpenExplorer = true };
        }


        public void Browse()
        {
            Notify(OpenBrowse, new NotificationEventArgs());
        }


        public void Generate()
        {
            if (string.IsNullOrWhiteSpace(Model.OutputPath))
                throw new ArgumentNullException("OutputPath");

            try
            {
                Generating = true;
                SendMessage(MessageTokens.Action, new NotificationEventArgs(ActionType.Working));
                _engine.Execute(Model.OutputPath, Model.Prefix, Model.Extension.Replace(".", ""), Model.FileSize, Model.TotalFiles, Model.SelectedFileNamingType);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message, ex);
                Generating = false;
            }
            SendMessage(MessageTokens.Action, new NotificationEventArgs(ActionType.Completed));
        }


        private void GenerateCompleted()
        {
            Generating = false;
            if (Model.OpenExplorer)
            {
                OpenOutputPathWindow();
            }
            Notify(GenerateComplete, new NotificationEventArgs(Model.OutputPath));
        }


        private void OpenOutputPathWindow()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "explorer.exe";
                process.StartInfo.Arguments = "/root," + Model.OutputPath;
                process.Start();
            }
        }


        private void NotifyError(string message, Exception error)
        {
            // Notify viewOnStatusChanged of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}
