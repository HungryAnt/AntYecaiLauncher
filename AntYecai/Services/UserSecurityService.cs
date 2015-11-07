using System;
using AntYecai.Http;
using AntYecai.Models;

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
            return userLoginResult;
        }
    }
}
