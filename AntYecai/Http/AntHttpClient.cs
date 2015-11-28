using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AntYecai.Http
{
    public class AntHttpClient
    {
        private const String MediaTypeJson = "application/json";
        private Uri _uri;

        public AntHttpClient(String endpoint)
        {
            _uri = new Uri(endpoint);
        }

        public void Path(String path)
        {
            _uri = new Uri(_uri, path);
        }

        public void Post<T>(T entity)
        {
            Uri uri = _uri;
            using (var httpClient = CreateHttpClient(uri.Host))
            {
                HttpResponseMessage response = httpClient.PostAsync(uri, CreateContent(entity)).Result;
                CheckResponseStatus(response);
            }
        }

        public T2 PostForResult<T1, T2>(T1 entity)
        {
            Uri uri = _uri;
            using (var httpClient = CreateHttpClient(uri.Host))
            {
                HttpResponseMessage response = httpClient.PostAsync(uri, CreateContent(entity)).Result;
                CheckResponseStatus(response);
                String jsonText = response.Content.ReadAsStringAsync().Result;
                return ToDataResult<T2>(jsonText);
            }
        }

        private static void CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                GameServerErrorInfo gameServerErrorInfo;
                try
                {
                    String jsonText = response.Content.ReadAsStringAsync().Result;
                    gameServerErrorInfo = ToDataResult<GameServerErrorInfo>(jsonText);
                }
                catch (Exception)
                {
                    String errorMessage = "HTTP Status: " + response.StatusCode.ToString() + 
                        " - Reason: " + response.ReasonPhrase;
                    throw new ApplicationException(errorMessage);
                }
                throw new GameServerHttpResponseException(gameServerErrorInfo);
            }
        }

        private static HttpClient CreateHttpClient(String host)
        {
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(3);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeJson));
            httpClient.DefaultRequestHeaders.Host = host;
            return httpClient;
        }

        private static StringContent CreateContent<T>(T entity)
        {
            String contentText = ToJsonText(entity);
            return new StringContent(contentText, Encoding.UTF8, MediaTypeJson);
        }

        private static String ToJsonText<T>(T entity)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, entity);
                // ms.Position = 0;

                return Encoding.UTF8.GetString(ms.ToArray());

//                using (StreamReader sr = new StreamReader(ms))
//                {
//                    String jsonText = sr.ReadToEnd();
//                    return jsonText;
//                }
            }
        }

        private static T ToDataResult<T>(String jsonText)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonText)))
            {
                return (T)jsonSerializer.ReadObject(ms);
            }
        }
    }
}
