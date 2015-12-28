using MahApps.Metro.Controls;

namespace FileGenerator.WpfUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly MainPageViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            var loc = new ViewModelLocator();
            _viewModel = loc.MainPageViewModel;
            DataContext = _viewModel;
        }
    }
}
