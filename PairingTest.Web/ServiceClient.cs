using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PairingTest.Web
{
    public class ServiceClient
    {
        static HttpClient _client;

        public ServiceClient()
        {
            string webApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];
            _client = new HttpClient();
            _client.BaseAddress = new Uri(webApiUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public HttpClient Instance { get { return _client; } }

    }
}