using System.Diagnostics;
using System.Windows;
using AntYecai.Views;

namespace AntYecai
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();

            foreach (Process item in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (item.Id != currentProcess.Id &&
                (item.StartTime - currentProcess.StartTime).TotalMilliseconds <= 0)
                {
                    item.Kill();

                    item.WaitForExit();

                    break;
                }
            }

            base.OnStartup(e);  

            base.OnStartup(e);

//            MainWindow mainWindow = new MainWindow();
//            mainWindow.ShowDialog();
        }
    }
}
