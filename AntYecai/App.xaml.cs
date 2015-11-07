using System.Diagnostics;
using System.Windows;
using AntYecai.Tools;
using AntYecai.Utils;
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

            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (process.Id != currentProcess.Id)
                {
                    MessageBoxUtil.ShowError("您已经启动了游戏!");
                    NativeWindowApiHelper.ShowWindowAsync(process.MainWindowHandle, NativeWindowApiHelper.SW_RESTORE);
                    NativeWindowApiHelper.SetForegroundWindow(process.MainWindowHandle);
                    currentProcess.Kill();
                }
            }

            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}
