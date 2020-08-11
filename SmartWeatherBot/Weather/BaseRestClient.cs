using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartWeatherBot.Weather
{
    public class BaseRestClient
    {
        public string BaseUrl { get; set; } = "http://localhost/";
        public int Timeout { get; set; } = 30;

        public BaseRestClient() { }

        public BaseRestClient(string url)
        {
            SetBaseUrl(url);
        }

        public BaseRestClient SetBaseUrl(string url)
        {
            BaseUrl = url.EndsWith("/") ? url : url + "/";
            return this;
        }

        public HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(Timeout > 0 ? Timeout : 30);           

            return client;
        }

        protected string GetFullPath(string path) => BaseUrl + path.TrimStart(new[] { '/' });

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            using (var client = GetHttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(GetFullPath(path));
                    return response;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<T> Get<T>(string path) where T: class
        {
            var response = await GetAsync(path);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var ContentLength = response.Content.Headers.ContentLength;
                        if (ContentLength.HasValue && ContentLength.Value > 0)
                        {
                            var result = await response.Content.ReadAsAsync<T>();
                            return result;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
