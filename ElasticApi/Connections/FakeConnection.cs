namespace ElasticApi.Connections
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class FakeConnection : IConnection
    {
        public Uri Endpoint { get; private set; }

        public FakeConnection(Uri endpoint)
        {
            this.Endpoint = endpoint;
        }

        public TResponse Head<TResponse>(IEnumerable<string> path, IDictionary<string, object> parameters)
        {
            Uri uri = MakeUri(this.Endpoint, path, parameters);

            return SendRequest<TResponse>(uri, null);
        }

        public TResponse Get<TResponse>(IEnumerable<string> path, IDictionary<string, object> parameters)
        {
            Uri uri = MakeUri(this.Endpoint, path, parameters);

            return SendRequest<TResponse>(uri, null);
        }

        public TResponse Post<TResponse>(IEnumerable<string> path, IDictionary<string, object> parameters, object body)
        {
            Uri uri = MakeUri(this.Endpoint, path, parameters);

            return SendRequest<TResponse>(uri, body);
        }

        public TResponse Put<TResponse>(IEnumerable<string> path, IDictionary<string, object> parameters, object body)
        {
            Uri uri = MakeUri(this.Endpoint, path, parameters);

            return SendRequest<TResponse>(uri, body);
        }

        public TResponse Delete<TResponse>(IEnumerable<string> path, IDictionary<string, object> parameters)
        {
            Uri uri = MakeUri(this.Endpoint, path, parameters);

            return SendRequest<TResponse>(uri, null);
        }

        private static Uri MakeUri(Uri endpoint, IEnumerable<string> path, IDictionary<string, object> parameters)
        {
            var builder = new UriBuilder(endpoint);

            builder.Path = string.Join("/", path);

            builder.Query = string.Join("&", parameters.Select(p => p.Value == null ? p.Key : p.Key + "=" + p.Value));

            return builder.Uri;
        }

        private static TResponse SendRequest<TResponse>(Uri uri, object body)
        {
            if (body != null)
            {
                var bodyData = JsonConvert.SerializeObject(body);

                Log.WriteLine(">>>> {0} - {1} - {2}", "UNKNOWN", uri, bodyData);
            }
            else
            {
                Log.WriteLine(">>>> {0} - {1}", "UNKNOWN", uri);
            }
//
//            using (var httpClient = new HttpClient())
//            {
//                using (var response = httpClient.SendAsync(request).Result)
//                {
//                    Log.WriteLine("<<<< HTTP RESPONSE ({0}) {1}", response.StatusCode, response.ReasonPhrase);
//                    
//                    using (var responseStream = response.Content.ReadAsStreamAsync().Result)
//                    {
//                        return ParseResponse<TResponse>(responseStream);
//                    }
//                }
//            }
			return default(TResponse);
        }

        private static TResponse ParseResponse<TResponse>(Stream responseStream)
        {
            using (var reader = new StreamReader(responseStream))
            {
                string response = reader.ReadToEnd();

                Log.WriteLine(string.Format("<<<< {0}", response));

                return JsonConvert.DeserializeObject<TResponse>(response);
            }
        }
    }
}
