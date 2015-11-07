using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntYecaiTest
{
    /// <summary>
    /// HttpClientTest 的摘要说明
    /// </summary>
    [TestClass]
    public class HttpClientTest
    {
        private const String ServerEndpoint = "http://localhost:8001/v1";

        public HttpClientTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [DataContract]
        class UserRegisterInfo
        {
            [DataMember(Name = "loginName")] 
            public String LoginName { get; set; }

            [DataMember(Name = "password")] 
            public String Password { get; set; }

            [DataMember(Name = "relatedUserId")] 
            public String RelatedUserId { get; set; }

            [DataMember(Name = "gender")] 
            public String Gender { get; set; }

            [DataMember(Name = "qq")] 
            public String QQ { get; set; }

            [DataMember(Name = "email")] 
            public String Email { get; set; }

            [DataMember(Name = "introduction")] 
            public String Introduction { get; set; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            using (var httpClient = new HttpClient())
            {
                Uri uri = new Uri(ServerEndpoint + "/userSecurity/register");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Host = uri.Host;

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

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(UserRegisterInfo));

                MemoryStream ms = new MemoryStream();
                jsonSerializer.WriteObject(ms, user);
                ms.Position = 0;

                StreamReader sr = new StreamReader(ms);
                String contentText = sr.ReadToEnd();
                StringContent theContent = new StringContent(contentText, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync(uri, theContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    String failureMsg = "HTTP Status: " + response.StatusCode.ToString() + " - Reason: " + response.ReasonPhrase; 
                }
            }
        }
    }
}
