using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class Helper
    {
        private static readonly Lazy<HttpClient> _lazyClient = new Lazy<HttpClient>(
            () =>
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "curl/7.53.0");
                return client;
            }
        );
        private static HttpClient _client
        {
            get
            {
                return _lazyClient.Value;
            }
        }
        internal static TextReader UrlToTextReader(string url)
        {
            var uri = new Uri(url);
            var uriStream = _client.GetAsync(uri).GetAwaiter().GetResult().Content.ReadAsStreamAsync().GetAwaiter().GetResult();
            TextReader uriReader = new StreamReader(uriStream);
            return uriReader;
        }
        private static IDictionary<string, Type> _sourceClasses = null;
        internal IDictionary<string, Type> GetAllSourceClasses()
        {
            if (_sourceClasses != null)
            {
                return _sourceClasses;
            }
            IDictionary<string, Type> sourcesDictionary = new Dictionary<string, Type>();
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            foreach (var type in currentAssembly.DefinedTypes)
            {
                var sourceInterfaceImplemented = false;
                foreach (var inter in type.ImplementedInterfaces)
                {
                    if (inter == typeof(IIndexConstituentsSource))
                    {
                        sourceInterfaceImplemented = true;
                        break;
                    }
                }
                if (sourceInterfaceImplemented)
                {
                    var constructor = type.GetConstructor(Type.EmptyTypes);
                    var instance = (IIndexConstituentsSource)constructor.Invoke(new object[] { });
                    sourcesDictionary[instance.IndexName()] = type;
                }
            }
            _sourceClasses = sourcesDictionary;
            return sourcesDictionary;
        }
    }
}
