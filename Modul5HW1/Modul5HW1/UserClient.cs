using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Modul5HW1.Models;

namespace Modul5HW1
{
    public class UserClient
    {
        private readonly string _baseUrl = "https://reqres.in/api/";
        private HttpClient _httpClient;
        public UserClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> MakeResponse<T>(HttpMethod method, string url, string content = null)
        {
            var message = Message(method, url, content);

            return await ServerRequestAsync<T>(message);
        }

        private HttpRequestMessage Message(HttpMethod method, string url, string content)
        {
            var message = new HttpRequestMessage();
            message.Method = method;
            message.RequestUri = new Uri($"{_baseUrl}{url}");
            if (content != null)
            {
                message.Content = new StringContent(content);
            }

            return message;
        }

        private async Task<T> ServerRequestAsync<T>(HttpRequestMessage message)
        {
            var response = await _httpClient.SendAsync(message);
            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<T>(data);

            return deserializedData;
        }
    }
}
