using System.Windows;
using System.Windows.Input;

namespace AntYecai.Views
{
    /// <summary>
    /// AuthorWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AuthorWindow : Window
    {
        public AuthorWindow()
        {
            InitializeComponent();
        }

        private void Main_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
