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
using AntYecai.ViewModels;

namespace AntYecai.Views
{
    /// <summary>
    /// GameEntryView.xaml 的交互逻辑
    /// </summary>
    public partial class GameEntryView : UserControl
    {
        private GameEntryViewModel GameEntryViewModel { get; set; }

        public event Action Logout;

        public GameEntryView()
        {
            InitializeComponent();
        }

        public void InitDataContext(GameEntryViewModel gameEntryViewModel)
        {
            GameEntryViewModel = gameEntryViewModel;
            this.DataContext = GameEntryViewModel;
        }

        private void buttonStartWindowMode_Click(object sender, RoutedEventArgs e)
        {
            GameEntryViewModel.Enter();
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
