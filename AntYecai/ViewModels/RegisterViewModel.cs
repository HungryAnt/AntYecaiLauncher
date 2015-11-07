using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AntYecai.Foundation;
using AntYecai.Models;
using AntYecai.Services;
using AntYecai.Utils;

namespace AntYecai.ViewModels
{
    public class RegisterViewModel : NotificationObject
    {
        private static readonly Regex UserIdRegex = new Regex(@"^[a-zA-Z0-9_-]{36}$");

        private String _loginName = String.Empty;

        public String LoginName
        {
            get { return _loginName; }
            set
            {
                _loginName = value;
                RaisePropertyChanged("LoginName");
            }
        }

        private String _password = String.Empty;

        public String Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        private String _repeatPassword = String.Empty;

        public String RepeatPassword
        {
            get { return _repeatPassword; }
            set
            {
                _repeatPassword = value;
                RaisePropertyChanged("RepeatPassword");
            }
        }

        private String _relatedUserId = String.Empty;

        public String RelatedUserId
        {
            get { return _relatedUserId; }
            set
            {
                _relatedUserId = value;
                RaisePropertyChanged("RelatedUserId");
            }
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
            if (Password.Length > 32)
            {
                message = "密码太长";
                return false;
            }
            if (Password != RepeatPassword)
            {
                message = "两次密码输入不一致";
                return false;
            }
            message = String.Empty;
            return true;
        }

        public bool TryValidateRelatedUserId(out string message)
        {
            if (RelatedUserId == String.Empty ||
                (RelatedUserId.Length == 36 && UserIdRegex.IsMatch(RelatedUserId)))
            {
                message = String.Empty;
                return true;
            }
            message = "userId错误";
            return false;
        }

        public void Clear()
        {
            LoginName = Password = RepeatPassword = RelatedUserId = String.Empty;
        }

        public void Register()
        {
            UserRegisterInfo userRegisterInfo = new UserRegisterInfo()
                {
                    LoginName = LoginName,
                    Password = Password,
                    RelatedUserId = RelatedUserId,
                    Gender = "Male",
                    QQ = "517377100",
                    Email = "517377100@qq.com",
                    Introduction = "软件开发者"
                };

            PlatformServiceManager.Instance.GetService<UserSecurityService>().Register(userRegisterInfo);
        }
    }
}
