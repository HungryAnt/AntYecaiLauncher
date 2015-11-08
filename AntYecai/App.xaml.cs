using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
            CheckRunning();
            CheckAppPath();

            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void CheckAppPath()
        {
            String gameDir = AppDomain.CurrentDomain.BaseDirectory;
            if (!CheckPath(gameDir))
            {
                MessageBox.Show("程序路径中不允许包含中文，否则将导致游戏无法启动，请进行修改\r\n" + gameDir, "错误",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private static bool CheckPath(string path)
        {
            const string pattern = @"^[a-zA-Z0-9-_\\: ]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(path);
        } 

        private static void CheckRunning()
        {
            bool isAppRunning;
            var mutex = new System.Threading.Mutex(true, "ant_yecaibuluo_startup", out isAppRunning);
            if (!isAppRunning)
            {
                MessageBoxUtil.ShowError("本程序已经在运行了，请不要重复运行！");
                ShowRunningAppWindow();
                Environment.Exit(1);
            }
        }

        private static void ShowRunningAppWindow()
        {
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (process.Id != currentProcess.Id)
                {
                    NativeWindowApiHelper.ShowWindowAsync(process.MainWindowHandle, NativeWindowApiHelper.SW_RESTORE);
                    NativeWindowApiHelper.SetForegroundWindow(process.MainWindowHandle);
                    break;
                }
            }
        }
    }
}
