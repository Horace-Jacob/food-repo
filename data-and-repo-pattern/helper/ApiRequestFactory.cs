using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace data_and_repo_pattern.helper
{
    public class ApiRequestFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiRequestFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> PostGetString<T>(string url, T entity, bool isCompressed = true, string AuthKey = "")
        {
            HttpRequestMessage httpRequestMessage;
            if (!string.IsNullOrEmpty(AuthKey))
            {
                httpRequestMessage = new HttpRequestMessage(
                 HttpMethod.Post, url)
                {
                    Headers =
                            {
                                { HeaderNames.Accept, "application/json" },
                                { HeaderNames.UserAgent, "Server" },
                                { HeaderNames.Authorization, AuthKey }
                            }
                };
            }
            else
            {
                httpRequestMessage = new HttpRequestMessage(
                  HttpMethod.Post, url)
                {
                    Headers =
                                {
                                    { HeaderNames.Accept, "application/json" },
                                    { HeaderNames.UserAgent, "Server" }
                                }
                };
            }

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); // Github API versioning
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Server"); // Github requires a user-agent
            if (!string.IsNullOrEmpty(AuthKey))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", AuthKey);
            }
            var poststring = new StringContent(
                                 JsonSerializer.Serialize(entity),
                                 Encoding.UTF8,
                                 Application.Json); // using static System.Net.Mime.MediaTypeNames;

            using var httpResponseMessage = await httpClient.PostAsync(url, poststring);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                return contentStream.ToString();
            }
            else
            {
                return null;
            }
        }
        public async Task<U> PostDiffRequest<T, U>(string url, T entity, bool isCompressed = true, string AuthKey = "")
        {
            HttpRequestMessage httpRequestMessage;
            if (!string.IsNullOrEmpty(AuthKey))
            {
                httpRequestMessage = new HttpRequestMessage(
                 HttpMethod.Post, url)
                {
                    Headers =
                        {
                            { HeaderNames.Accept, "application/json" },
                            { HeaderNames.UserAgent, "Server" },
                             { HeaderNames.Authorization, AuthKey }
                        }
                };
            }
            else
            {
                httpRequestMessage = new HttpRequestMessage(
                   HttpMethod.Post, url)
                {
                    Headers =
                        {
                            { HeaderNames.Accept, "application/json" },
                            { HeaderNames.UserAgent, "Server" }
                        }
                };
            }

            var httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); // Github API versioning
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Server"); // Github requires a user-agent
            if (!string.IsNullOrEmpty(AuthKey))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", AuthKey);
            }
            var poststring = new StringContent(
                                 JsonSerializer.Serialize(entity),
                                 Encoding.UTF8,
                                 Application.Json); // using static System.Net.Mime.MediaTypeNames;
            try
            {
                using var httpResponseMessage = await httpClient.PostAsync(url, poststring);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using (var contentStream = httpResponseMessage.Content.ReadAsStreamAsync().Result)
                    {
                        StreamReader reader = new StreamReader(contentStream);
                        string text = reader.ReadToEnd();
                        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<U>(text);
                        return data;
                    }
                }
                else
                {
                    return default(U);
                }
            }
            catch (Exception ex)
            {
                return default(U);
            }

        }

        public async Task<T> GetRequest<T>(string url, bool isCompressed = false, string rootUrl = null, string AuthKey = "")
        {
            HttpRequestMessage httpRequestMessage;
            if (!string.IsNullOrEmpty(AuthKey))
            {
                httpRequestMessage = new HttpRequestMessage(
                 HttpMethod.Get, url)
                {
                    Headers =
                        {
                            { HeaderNames.Accept, "application/json" },
                            { HeaderNames.UserAgent, "Server" },
                             { HeaderNames.Authorization, AuthKey }
                        }
                };
            }
            else
            {
                httpRequestMessage = new HttpRequestMessage(
                   HttpMethod.Get, url)
                {
                    Headers =
                        {
                            { HeaderNames.Accept, "application/json" },
                            { HeaderNames.UserAgent, "Server" }
                        }
                };
            }

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); // Github API versioning
                                                                                // httpClient.DefaultRequestHeaders.Add("User-Agent", "Server"); // Github requires a user-agent
            if (!string.IsNullOrEmpty(AuthKey))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", AuthKey);
            }
            //var vbb = await httpClient.GetStringAsync(url);
            //var data = JsonSerializer.Deserialize<T>(text);
            //return data;
            using var httpResponseMessage = await httpClient.GetAsync(url);
            try
            {
                if (httpResponseMessage.IsSuccessStatusCode)

                {
                    using (var contentStream = httpResponseMessage.Content.ReadAsStreamAsync().Result)
                    {
                        StreamReader reader = new StreamReader(contentStream, Encoding.UTF8);
                        string text = reader.ReadToEnd();
                        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(text);
                        return data;
                    }
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                var aa = ex;
                return default(T);
            }
        }
        public async Task<T> PostRequest<T>(string url, T entity, string rootUrl = null, string AuthKey = "")
        {

            HttpRequestMessage httpRequestMessage;
            if (!string.IsNullOrEmpty(AuthKey))
            {
                httpRequestMessage = new HttpRequestMessage(
                 HttpMethod.Post, url)
                {
                    Headers =
                        {
                            { HeaderNames.Accept, "application/json" },
                            { HeaderNames.UserAgent, "Server" },
                             { HeaderNames.Authorization, AuthKey }
                        }
                };
            }
            else
            {
                httpRequestMessage = new HttpRequestMessage(
                   HttpMethod.Post, url)
                {
                    Headers =
                        {
                            { HeaderNames.Accept, "application/json" },
                            { HeaderNames.UserAgent, "Server" }
                        }
                };
            }

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); // Github API versioning
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Server"); // Github requires a user-agent
            if (!string.IsNullOrEmpty(AuthKey))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", AuthKey);
            }
            var poststring = new StringContent(
                                 JsonSerializer.Serialize(entity),
                                 Encoding.UTF8,
                                 Application.Json); // using static System.Net.Mime.MediaTypeNames;

            using var httpResponseMessage = await httpClient.PostAsync(url, poststring);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using (var contentStream = httpResponseMessage.Content.ReadAsStreamAsync().Result)
                {
                    StreamReader reader = new StreamReader(contentStream);
                    string text = reader.ReadToEnd();
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(text);
                    return data;
                }
            }
            else
            {
                return default(T);
            }

        }
    }
}
