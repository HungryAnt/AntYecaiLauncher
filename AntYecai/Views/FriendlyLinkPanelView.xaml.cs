using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using AntYecai.Models;
using AntYecai.ViewModels;

namespace AntYecai.Views
{
    /// <summary>
    /// FriendlyLinkPanelView.xaml 的交互逻辑
    /// </summary>
    public partial class FriendlyLinkPanelView : UserControl
    {
        public FriendlyLinkPanelView()
        {
            InitializeComponent();
            InitDataContext();
        }

        public void InitDataContext()
        {
            this.DataContext = new FriendlyLinkPanelViewModel();
        }

        private void FriendlyLinks_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var friendlyLink = FriendlyLinks.SelectedItem as FriendlyLink;
            if (friendlyLink != null && !String.IsNullOrWhiteSpace(friendlyLink.Url))
            {
                Process.Start(friendlyLink.Url);
            }
            FriendlyLinks.SelectedItem = null;
        }
    }
}
