using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

namespace AntYecai.Views.Common
{
    /// <summary>
    /// AdHao123Control.xaml 的交互逻辑
    /// </summary>
    public partial class AdHao123Control : UserControl
    {
        public AdHao123Control()
        {
            InitializeComponent();
        }

        private void buttonHomePageSetting_Click(object sender, RoutedEventArgs e)
        {
            const string key = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main";
            const string valueName = "Start Page";
            Registry.SetValue(key, valueName, GameConfig.ActualHao123Url);
        }

        private void AdMainPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(GameConfig.Hao123Url);
        }
    }
}
