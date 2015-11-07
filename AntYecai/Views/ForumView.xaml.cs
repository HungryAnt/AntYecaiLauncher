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
using mshtml;

namespace AntYecai.Views
{
    /// <summary>
    /// ForumView.xaml 的交互逻辑
    /// </summary>
    public partial class ForumView : UserControl
    {
        private const String HomePage = "http://180.76.156.183:8000/bbs/";

        public ForumView()
        {
            InitializeComponent();
            wb.Navigate(HomePage);
            wb.Navigating += new NavigatingCancelEventHandler(wb_Navigating);
            wb.LoadCompleted += new LoadCompletedEventHandler(wb_LoadCompleted);
        }

        void wb_LoadCompleted(object sender, NavigationEventArgs e)
        {
            IHTMLDocument2 document = (IHTMLDocument2)wb.Document;
            foreach (IHTMLElement link in document.links)
            {
                link.setAttribute("target", "_self");
            }
            foreach (IHTMLElement form in document.forms)
            {
                form.setAttribute("target", "_self");
            }


        }

        void wb_Navigating(object sender, NavigatingCancelEventArgs e)
        {
//            MessageBox.Show(e.Uri.ToString());
        }

        private void buttonGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (wb.CanGoBack)
            {
                wb.GoBack();                
            }
        }

        private void buttonGoForward_Click(object sender, RoutedEventArgs e)
        {
            if (wb.CanGoForward)
            {
                wb.GoForward();
            }
        }

        private void buttonOpenInBrowser_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(HomePage);
        }

        private void buttonHomePage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
