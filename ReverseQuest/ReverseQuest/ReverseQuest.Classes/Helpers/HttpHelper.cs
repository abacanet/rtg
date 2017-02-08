using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Threading;
using System.Security.Cryptography;
using System.Net.Http.Headers;

namespace ReverseQuest.Classes.Helpers
{
    public class HttpHelper
    {
        public async static Task<T> HttpGetAsync<T>(string RequestURL, CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            using (var client = GetHttpClient(customDelegatingHandler, AdditionalHeaders))
            {
                HttpResponseMessage response = await client.GetAsync(RequestURL);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }
        }
        public async static Task<string> HttpGetStringAsync(string RequestURL, CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            using (var client = GetHttpClient(customDelegatingHandler, AdditionalHeaders))
            {
                HttpResponseMessage response = await client.GetAsync(RequestURL);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static T HttpGet<T>(string RequestURL, CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            using (var client = new MyWebClient())
            {
                if (AdditionalHeaders != null)
                {
                    AdditionalHeaders.ForEach(d =>
                    {
                        client.Headers.Add(d.Item1, d.Item2);
                    });
                }

                var json = client.DownloadString(RequestURL);
                T response = JsonConvert.DeserializeObject<T>(json);

                return response;
            }
        }

        public async static Task<TResult> HttpPostJsonAsync<TRequest, TResult>(string RequestURL, TRequest Value, CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            using (var client = GetHttpClient(customDelegatingHandler, AdditionalHeaders))
            {
                MediaTypeFormatter formatter = new JsonMediaTypeFormatter();
                HttpResponseMessage response = await client.PostAsync<TRequest>(RequestURL, Value, formatter);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<TResult>();
            }
        }

        public async static Task<TResult> HttpPostXMLAsync<TRequest, TResult>(string RequestURL, TRequest Value, CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            using (var client = GetHttpClient(customDelegatingHandler, AdditionalHeaders))
            {
                MediaTypeFormatter formatter = new XmlMediaTypeFormatter();

                HttpResponseMessage response = await client.PostAsync<TRequest>(RequestURL, Value, formatter);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<TResult>();
            }
        }
        public async static Task<HttpResponseMessage> HttpPostAsync(string RequestURL, HttpContent content, CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            string fafas = await content.ReadAsStringAsync();
            using (var client = GetHttpClient(customDelegatingHandler, AdditionalHeaders))
            {
                //MediaTypeFormatter formatter = new XmlMediaTypeFormatter();

                HttpResponseMessage response = await client.PostAsync(RequestURL, content);
                response.EnsureSuccessStatusCode();
                return response;
            }
        }



        public async static Task HttpPutJsonAsync(string RequestURL, CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            using (var client = GetHttpClient(customDelegatingHandler, AdditionalHeaders))
            {
                MediaTypeFormatter formatter = new JsonMediaTypeFormatter();
                HttpResponseMessage response = await client.PutAsync(RequestURL, new StringContent(""), formatter);
                response.EnsureSuccessStatusCode();
            }
        }

        public async static Task HttpPutXMLAsync(string RequestURL, CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            using (var client = GetHttpClient(customDelegatingHandler, AdditionalHeaders))
            {
                MediaTypeFormatter formatter = new XmlMediaTypeFormatter();
                HttpResponseMessage response = await client.PutAsync(RequestURL, new StringContent(""), formatter);
                response.EnsureSuccessStatusCode();
            }
        }

        public async static Task HttpDeleteAsync(string RequestURL, CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            using (var client = GetHttpClient(customDelegatingHandler, AdditionalHeaders))
            {
                HttpResponseMessage response = await client.DeleteAsync(RequestURL);
                response.EnsureSuccessStatusCode();
            }
        }

        private static HttpClient GetHttpClient(CustomDelegatingHandler customDelegatingHandler = null, List<Tuple<string, string>> AdditionalHeaders = null)
        {
            HttpClient client;

            if (customDelegatingHandler != null)
            {
                client = HttpClientFactory.Create(customDelegatingHandler);
            }
            else
            {
                client = new HttpClient();
            }

            if (AdditionalHeaders != null)
            {
                AdditionalHeaders.ForEach(header =>
                {
                    if (client.DefaultRequestHeaders.Contains(header.Item1))
                        client.DefaultRequestHeaders.Remove(header.Item1);
                    //client.DefaultRequestHeaders.Add(header.Item1, header.Item2);
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Item1, header.Item2);

                });
            }

            return client;
        }

        class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                if (request is HttpWebRequest)
                {
                    (request as HttpWebRequest).KeepAlive = true;
                }
                return request;
            }
        }

    }

    public class CustomDelegatingHandler : DelegatingHandler
    {
        //public CustomDelegatingHandler(string userId)
        //{
        //    this.APPId = userId;
        //}

        //Obtained from the server earlier, APIKey MUST be stored securly and in App.Config
        private string APPId = "4d53bce03ec34c0a911182d4c228ee6c";
        private string APIKey = "bPsXT2/AjaXeRGTiuoIKT8Ig3e92wT/71g69VQQBHUY=";//"A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=";
        //bPsXT2/AjaXeRGTiuoIKT8Ig3e92wT/71g69VQQBHUY=

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            HttpResponseMessage response = null;
            string requestContentBase64String = string.Empty;

            string requestUri = System.Web.HttpUtility.UrlEncode(request.RequestUri.AbsoluteUri.ToLower());

            string requestHttpMethod = request.Method.Method;

            //Calculate UNIX time
            DateTime epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = DateTime.UtcNow - epochStart;
            string requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();

            //create random nonce for each request
            string nonce = Guid.NewGuid().ToString("N");

            //Checking if the request contains body, usually will be null wiht HTTP GET and DELETE
            if (request.Content != null)
            {
                byte[] content = await request.Content.ReadAsByteArrayAsync();
                MD5 md5 = MD5.Create();
                //Hashing the request body, any change in request body will result in different hash, we'll incure message integrity
                byte[] requestContentHash = md5.ComputeHash(content);
                requestContentBase64String = Convert.ToBase64String(requestContentHash);
            }

            //Creating the raw signature string
            string signatureRawData = String.Format("{0}{1}{2}{3}{4}{5}", APPId, requestHttpMethod, requestUri, requestTimeStamp, nonce, requestContentBase64String);

            var secretKeyByteArray = Convert.FromBase64String(APIKey);

            byte[] signature = Encoding.UTF8.GetBytes(signatureRawData);

            using (HMACSHA256 hmac = new HMACSHA256(secretKeyByteArray))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);
                string requestSignatureBase64String = Convert.ToBase64String(signatureBytes);
                //Setting the values in the Authorization header using custom scheme (amx)
                request.Headers.Authorization = new AuthenticationHeaderValue("amx", string.Format("{0}:{1}:{2}:{3}", APPId, requestSignatureBase64String, nonce, requestTimeStamp));
            }

            response = await base.SendAsync(request, cancellationToken);

            return response;
        }

        private static string GenerateAPPKey()
        {
            string APIKey;
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                byte[] secretKeyByteArray = new byte[32]; //256 bit
                cryptoProvider.GetBytes(secretKeyByteArray);
                APIKey = Convert.ToBase64String(secretKeyByteArray);
            }

            return APIKey;
        }
    }
}
