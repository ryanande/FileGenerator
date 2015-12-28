using System;
using System.Collections.Generic;
using SimpleMvvmToolkit;
using System.Windows.Controls;

namespace FileGenerator.WpfUi
{
    public class MainPageViewModel : ViewModelBase<MainPageViewModel>
    {
           public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        private UserControl _CurrentView;
        public UserControl CurrentView
        {
            get
            {
                return _CurrentView;
            }
            set
            {
                _CurrentView = value;
                NotifyPropertyChanged(m => m.CurrentView);
            }
        }

        public Stack<UserControl> ControlStack { get; set; }


        public MainPageViewModel()
        {
            RegisterToReceiveMessages(MessageTokens.Navigation, OnNavigationRequested);
            ControlStack = new Stack<UserControl>();
            CurrentView = new SettingsView();            
        }

        
        void OnNavigationRequested(object sender, NotificationEventArgs e)
        {
            if (e.Message == ControlNames.Settings)
            {
                ControlStack.Push(CurrentView);
                CurrentView = new SettingsView();
            }
            else
            {
                CurrentView = ControlStack.Pop();
            }
        }

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}
