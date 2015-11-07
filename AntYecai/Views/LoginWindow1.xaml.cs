using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using AntYecai.Models;

namespace AntYecai.Views
{
    /// <summary>
    /// LoginWindow1.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow1 : Window
    {
        public LoginWindow1()
        {
            InitializeComponent();
        }

        private void Homepage_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(GameConfig.HomePageUrl);
        }

        private void Author_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AuthorWindow authorWindow = new AuthorWindow();
            authorWindow.ShowDialog();
        }
    }
}
