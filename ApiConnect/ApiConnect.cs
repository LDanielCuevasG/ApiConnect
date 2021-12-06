using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnect
{
    public class ApiConnect<T>
    {

        private string BaseAddress;
        public string Method { get; set; }
        public Dictionary<string, string> Headers { get; set; }


        public ApiConnect(string baseAddress) {
            BaseAddress = baseAddress;
        }


        public T Call() {
            return Call(HttpMethods.Get);
        }

        public T Call(HttpMethods httpMethod) {
            return Call(httpMethod, null);
        }

        public T Call(HttpMethods httpMethod, Object data) {
            return Call(httpMethod, data, MediaTypes.Json);
        }

        public T Call(HttpMethods httpMethod, Object data, MediaTypes mediaType)
        {

            HttpContent content = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);
                    client.BaseAddress = new Uri(BaseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();

                    if (Headers != null && Headers.Count > 0) {
                        foreach (KeyValuePair<string, string> header in Headers) {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }

                    if (data != null) {
                        content = DefineContent(data, mediaType);
                    }

                    HttpResponseMessage response = null;

                    switch (httpMethod)
                    {
                        case HttpMethods.Get:
                            response = client.GetAsync(Method).Result;
                            break;
                        case HttpMethods.Post:
                            response = client.PostAsync(Method, content).Result;
                            break;
                        case HttpMethods.Put:
                            response = client.PutAsync(Method, content).Result;
                            break;
                        case HttpMethods.Delete:
                            response = client.DeleteAsync(Method).Result;
                            break;
                    }

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    T responseObject = JsonConvert.DeserializeObject<T>(responseBody);
                    return responseObject;
                }
            }
            catch (Exception e) {
                return default(T);
            }
        }


        private HttpContent DefineContent(object data, MediaTypes mediaType)
        {
            HttpContent content = null;

            if (data != null)
            {
                if (mediaType == MediaTypes.Json) {
                    content = ApiContent.GetJsonContent(data);
                }
                else if (mediaType == MediaTypes.Form) {
                    content = ApiContent.GetFormContent(data);
                }
            }

            return content;
        }

    }
}
