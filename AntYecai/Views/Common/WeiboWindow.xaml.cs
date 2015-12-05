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

namespace AntYecai.Views.Common
{
    /// <summary>
    /// WeiboWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WeiboWindow : Window
    {
        public WeiboWindow()
        {
            InitializeComponent();
        }

        private void Main_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
