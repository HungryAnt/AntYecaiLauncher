using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntYecai.Foundation;
using AntYecai.Models;
using AntYecai.Services;
using AntYecai.Utils;

namespace AntYecai.ViewModels
{
    public class LoginViewModel : NotificationObject
    {
        private String _loginName = String.Empty;
        private string _password = String.Empty;

        public String LoginName
        {
            get { return _loginName; }
            set
            {
                _loginName = value;
                RaisePropertyChanged("LoginName");
            }
        }

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool TryValidateLoginName(out string message)
        {
            return ValidationUtil.TryValidateLoginName(LoginName, out message);
        }

        public bool TryValidatePassword(out String message)
        {
            if (String.IsNullOrWhiteSpace(Password))
            {
                message = "密码不得为空";
                return false;
            }
            if (Password.Length < 3)
            {
                message = "密码太短";
                return false;
            }
            message = String.Empty;
            return true;
        }

        public UserLoginResult Login()
        {
            UserLoginInfo userLoginInfo = new UserLoginInfo()
                {
                    LoginName = LoginName,
                    Password = Password
                };
            return PlatformServiceManager.Instance.GetService<UserSecurityService>().Login(userLoginInfo);
        }
    }
}
