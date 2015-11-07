using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AntYecai.ViewModels;

namespace AntYecai.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : UserControl
    {
        private LoginViewModel LoginViewModel { get; set; }

        public event Action Register;
        public event Action Login;

        public LoginView()
        {
            InitializeComponent();
        }

        public void InitDataContext(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
            this.DataContext = LoginViewModel;
        }

        private void ClearError()
        {
            loginNameError.Text = passwordError.Text = String.Empty;
        }

        private void Register_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Register != null)
            {
                Register();
            }
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateLoginName() || !ValidatePassword())
            {
                return;
            }

            if (Login != null)
            {
                Login();
            }
        }

        private void loginName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClearError();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginViewModel.Password = password.Password;
            ClearError();
        }

        private bool ValidateLoginName()
        {
            loginNameError.Text = String.Empty;
            String message;
            if (!LoginViewModel.TryValidateLoginName(out message))
            {
                loginNameError.Text = message;
                return false;
            }
            return true;
        }

        private bool ValidatePassword()
        {
            passwordError.Text = String.Empty;
            String message;
            if (!LoginViewModel.TryValidatePassword(out message))
            {
                passwordError.Text = message;
                return false;
            }
            return true;
        }
    }
}
