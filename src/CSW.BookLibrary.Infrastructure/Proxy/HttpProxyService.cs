using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace CSW.BookLibrary.Infrastructure.Proxy
{
    public class HttpProxyService : IHttpProxyService, IDisposable
    {
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, Dictionary<string, string> headers)
        {
            try
            {
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        request.Headers.Add(item.Key, (string)item.Value);
                    }
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("ApiBaseAddress"));
                    HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);

                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await this.SendAsync(request, headers);

            return response;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T resource, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new ObjectContent<T>(resource, new JsonMediaTypeFormatter() { });

            var response = await this.SendAsync(request, headers);

            return response;
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string url, T resource, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Content = new ObjectContent<T>(resource, new JsonMediaTypeFormatter() { });

            var response = await this.SendAsync(request, headers);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await this.SendAsync(request, headers);

            return response;
        }

        public void Dispose()
        {

        }
    }
}
