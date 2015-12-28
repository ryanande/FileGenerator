using System;
using FileGenerator.Core;

namespace FileGenerator.WpfUi
{
    public class ViewModelLocator
    {

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return new MainPageViewModel();
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get
            {
                return new SettingsViewModel(new Engine());
            }
        }
    }
}
