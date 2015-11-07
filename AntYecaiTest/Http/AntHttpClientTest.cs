using System;
using AntYecai.Http;
using AntYecai.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace AntYecaiTest.Http
{
    /// <summary>
    ///这是 AntHttpClientTest 的测试类，旨在
    ///包含所有 AntHttpClientTest 单元测试
    ///</summary>
    [TestClass()]
    public class AntHttpClientTest
    {
        private const String ServerEndpoint = "http://localhost:8001/";

        [TestMethod()]
        public void PostTest()
        {
            AntHttpClient client = new AntHttpClient(ServerEndpoint);
            client.Path("/v1/userSecurity/register");

            UserRegisterInfo user = new UserRegisterInfo()
                {
                    LoginName = "ant",
                    Password = "123456",
                    RelatedUserId = "",
                    Gender = "Male",
                    QQ = "517377100",
                    Email = "517377100@qq.com",
                    Introduction = "软件开发者"
                };

            client.Post(user);
        }
    }
}
