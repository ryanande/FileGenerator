using Ookii.Dialogs.Wpf;
using SimpleMvvmToolkit;
using System;
using System.Windows.Controls;

namespace FileGenerator.WpfUi
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        private readonly SettingsViewModel _viewModel;
        public SettingsView()
        {
            InitializeComponent();            

            _viewModel = (SettingsViewModel)DataContext;
            if (_viewModel != null)
            {
                _viewModel.ErrorNotice += App.OnErrorNotice;
                _viewModel.OpenBrowse += OnOpenBrowse;
                _viewModel.GenerationStarted += OnGenerationStarted;
                _viewModel.GenerateComplete += OnGenerateComplete;
            }
        }

        void OnOpenBrowse(object sender, NotificationEventArgs e)
        {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog { ShowNewFolderButton = true };
            if ((bool)dialog.ShowDialog())
            {
                _viewModel.Model.OutputPath = dialog.SelectedPath;
            }
        }

        void OnGenerationStarted(object sender, NotificationEventArgs e)
        {

        }

        void OnGenerateComplete(object sender, NotificationEventArgs e)
        {
        
        
        }

    }
}
