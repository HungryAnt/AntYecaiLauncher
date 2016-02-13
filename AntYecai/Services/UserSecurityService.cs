using System;
using AntYecai.Http;
using AntYecai.Models;
using Microsoft.Win32;

namespace AntYecai.Services
{
    public class UserSecurityService
    {
        public void Register(UserRegisterInfo userRegisterInfo)
        {
            AntHttpClient client = new AntHttpClient(GameConfig.ApiServerEndpoint);
            client.Path("/v1/userSecurity/register");
            client.Post(userRegisterInfo);
        }

        public UserLoginResult Login(UserLoginInfo userLoginInfo)
        {
            AntHttpClient client = new AntHttpClient(GameConfig.ApiServerEndpoint);
            client.Path("/v1/userSecurity/login");
            UserLoginResult userLoginResult = client.PostForResult<UserLoginInfo, UserLoginResult>(userLoginInfo);
            if (userLoginResult.Success)
            {
                CachedLoginName = userLoginInfo.LoginName;
            }
            return userLoginResult;
        }

        private const string CachedLoginNameKeyName = @"HKEY_CURRENT_USER\Software\AntSoft\Yecai\Main";
        private const string CachedLoginNameValueName = "CachedLoginName";

        public String CachedLoginName
        {
            get
            {
                return Registry.GetValue(CachedLoginNameKeyName, CachedLoginNameValueName, String.Empty).ToString();
            }
            private set
            {
                Registry.SetValue(CachedLoginNameKeyName, CachedLoginNameValueName, value);
            }
        }
    }
}
