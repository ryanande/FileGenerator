using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using log4net;
using SimpleMvvmToolkit;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace FileGenerator.WpfUi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ErrorTitle = "Unhandled Exception!";
        public static readonly ILog AppLog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public App()
        {
            Application.Current.DispatcherUnhandledException += App_Unhandled;
            AppDomain.CurrentDomain.UnhandledException += Application_UnhandledException;            
            AppLog.Info("FileGenerator Started up successfully....");
        }

        public void App_Unhandled(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            GetRecursiveErrors(e.Exception);
            e.Handled = true;
            Alert(e.Exception);
        }

        private void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            GetRecursiveErrors(ex);
            Alert(ex);
        }

        public static void OnErrorNotice(object sender, NotificationEventArgs<Exception> e)
        {
            GetRecursiveErrors(e.Data);
            Alert(e.Data);
        }

        private static void Alert(Exception ex)
        {
            // ultimately, this should be a nice window with maybe a grid with all exceptions...
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ex.Message);
            MessageBox.Show(sb.ToString(), ErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private static string GetRecursiveErrors(Exception e)
        {
            string msg = e.InnerException != null ? GetRecursiveErrors(e.InnerException) : "";

            msg += e.Message;
            AppLog.Error(e.Message, e);
            return msg;
        }
    }
}
