using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AntYecai.Views.Dialog
{
    /// <summary>
    /// ExitWindow2.xaml 的交互逻辑
    /// </summary>
    public partial class ExitWindow2 : Window
    {
        public enum State
        {
            NotifyIcon,
            DirectExitGame,
            Cancel
        }

        public State CloseWindowState { get; private set; }

        public ExitWindow2()
        {
            InitializeComponent();
        }

        private void buttonNotifyIcon_Click(object sender, RoutedEventArgs e)
        {
            CloseWindowState = State.NotifyIcon;
            Close();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            CloseWindowState = State.DirectExitGame;
            Close();
        }

        private void Main_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CloseWindowState = State.Cancel;
            Close();
        }
    }
}
