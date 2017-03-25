using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSW.BookLibrary.Infrastructure.Proxy
{
    public interface IHttpProxyService : IDisposable
    {
        Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers = null);
        Task<HttpResponseMessage> PostAsync<T>(string url, T resource, Dictionary<string, string> headers = null);
        Task<HttpResponseMessage> PutAsync<T>(string url, T resource, Dictionary<string, string> headers = null);
        Task<HttpResponseMessage> DeleteAsync(string url, Dictionary<string, string> headers = null);
    }
}
