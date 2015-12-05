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
    /// CommonWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CommonWindow : Window
    {
        public CommonWindow()
        {
            InitializeComponent();
        }

        public void SetTitle(String title)
        {
            Title = title;
        }

        public void SetContentControl(Control control)
        {
            contentBorder.Child = control;
        }

        private void Main_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
