using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AntYecai.Views
{
    /// <summary>
    /// GameEntryView.xaml 的交互逻辑
    /// </summary>
    public partial class GameEntryView : UserControl
    {
        public event Action Logout;

        public GameEntryView()
        {
            InitializeComponent();
        }

        private void buttonStartWindowMode_Click(object sender, RoutedEventArgs e)
        {
            // Directory.SetCurrentDirectory("D:\\dev\\ruby\\ruby-game\\output0-7-1");
            Process.Start("yecaigame_0_7_1_beta.exe");
        }

        private void buttonStartFullscreenMode_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            if (Logout != null)
            {
                Logout();
            }
        }
    }
}
