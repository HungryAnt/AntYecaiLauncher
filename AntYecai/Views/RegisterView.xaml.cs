using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using AntYecai.Types;
using AntYecai.ViewModels;
using Microsoft.Win32;

namespace AntYecai.Views
{
    /// <summary>
    /// RegisterView.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public event Action Cancel;
        public event Action Register;
        private RegisterViewModel RegisterViewModel { get; set; }

        public RegisterView()
        {
            InitializeComponent();
        }

        public void InitDataContext(RegisterViewModel registerViewModel)
        {
            RegisterViewModel = registerViewModel;
            this.DataContext = RegisterViewModel;

            radioButtonGenderSecret.IsChecked = true;
        }

        public void StartToDisplay()
        {
            RegisterViewModel.Clear();
            password.Password = repeatPassword.Password = String.Empty;
            loginNameError.Text = passwordError.Text = relatedUserIdError.Text = String.Empty;
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            if (Cancel !=  null)
            {
                Cancel();
            }
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            RegisterViewModel.Password = password.Password;
            ValidatePassword();
        }

        private void repeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            RegisterViewModel.RepeatPassword = repeatPassword.Password;
            ValidatePassword();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            ValidateLoginName();
            ValidatePassword();
            ValidateRelatedUserId();

            String message;
            if (!RegisterViewModel.TryValidateLoginName(out message))
            {
                return;
            }

            if (!RegisterViewModel.TryValidatePassword(out message))
            {
                return;
            }

            if (!RegisterViewModel.TryValidateRelatedUserId(out message))
            {
                return;
            }

            if (Register != null)
            {
                Register();
            }
        }

        private void loginName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateLoginName();
        }

        private void textBoxRelatedUserId_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateRelatedUserId();
        }

        private void ValidateLoginName()
        {
            loginNameError.Text = String.Empty;
            String message;
            if (!RegisterViewModel.TryValidateLoginName(out message))
            {
                loginNameError.Text = message;
            }
        }

        private void ValidatePassword()
        {
            passwordError.Text = String.Empty;
            String message;
            if (!RegisterViewModel.TryValidatePassword(out message))
            {
                passwordError.Text = message;
            }
        }

        private void ValidateRelatedUserId()
        {
            relatedUserIdError.Text = String.Empty;
            String message;
            if (!RegisterViewModel.TryValidateRelatedUserId(out message))
            {
                relatedUserIdError.Text = message;
            }
        }

        private void browserUser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = string.Format("user.dat({0})|{0}|所有文件(*.*)|*.*", string.Join(";", new String[] {"*.dat"}))
                };
            openFileDialog.ShowDialog();
            string userDataFilePath = openFileDialog.FileName;
            if (File.Exists(userDataFilePath))
            {
                String userId = LoadUserData(userDataFilePath);
                RegisterViewModel.RelatedUserId = userId;
                ValidateRelatedUserId();
            }
        }

        private String LoadUserData(String userDataFilePath)
        {
            using (TextReader reader = new StreamReader(userDataFilePath))
            {
                return reader.ReadLine();
            }
        }

        private void buttonClearUserId_Click(object sender, RoutedEventArgs e)
        {
            RegisterViewModel.RelatedUserId = String.Empty;
            ValidateRelatedUserId();
        }

        private void genderSecret_Checked(object sender, RoutedEventArgs e)
        {
            RegisterViewModel.Gender = Gender.Unknown.ToString();
        }

        private void genderMale_Checked(object sender, RoutedEventArgs e)
        {
            RegisterViewModel.Gender = Gender.Male.ToString();
        }

        private void genderFemale_Checked(object sender, RoutedEventArgs e)
        {
            RegisterViewModel.Gender = Gender.Female.ToString();
        }
    }
}
