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

        public bool Login(UserLoginInfo userLoginInfo)
        {
            AntHttpClient client = new AntHttpClient(GameConfig.ApiServerEndpoint);
            client.Path("/v1/userSecurity/login");
            bool success = client.PostForResult<UserLoginInfo, bool>(userLoginInfo);
            return success;
        }
    }
}
