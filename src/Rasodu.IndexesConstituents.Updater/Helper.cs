using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;

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
            foreach (var typeInfo in currentAssembly.DefinedTypes)
            {
                if (CheckClassImplementsInterface(typeInfo, typeof(IIndexConstituentsSource)))
                {
                    var constructor = typeInfo.GetConstructor(Type.EmptyTypes);
                    var instance = (IIndexConstituentsSource)constructor.Invoke(new object[] { });
                    sourcesDictionary[instance.IndexName()] = typeInfo;
                }
            }
            _sourceClasses = sourcesDictionary;
            return sourcesDictionary;
        }
        private IDictionary<string, Type> _writerClasses = null;
        internal IDictionary<string, Type> GetAllWriterClasses()
        {
            if (_writerClasses != null)
            {
                return _writerClasses;
            }
            var writerClasses = new Dictionary<string, Type>();
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            foreach (var typeInfo in currentAssembly.DefinedTypes)
            {
                if (CheckClassImplementsInterface(typeInfo, typeof(IIndexConstituentsDiskWriter)))
                {
                    var instance = (IIndexConstituentsDiskWriter)FormatterServices.GetUninitializedObject(typeInfo);
                    writerClasses[instance.FileExtension()] = typeInfo;
                }
            }
            _writerClasses = writerClasses;
            return writerClasses;
        }
        private bool CheckClassImplementsInterface(TypeInfo checkClass, Type checkInterface)
        {
            foreach (var inter in checkClass.ImplementedInterfaces)
            {
                if (inter == checkInterface)
                {
                    return true;
                }
            }
            return false;
        }
        internal TextWriter GetTextWriterForExistingFileInTree(string fileName)
        {
            var parentDir = ".." + Path.DirectorySeparatorChar;// "../"
            for (var baseDir = parentDir; Directory.Exists(baseDir); baseDir += parentDir)
            {
                var dataDir = baseDir + "Data" + Path.DirectorySeparatorChar;// "Data/";
                if (File.Exists(dataDir + "README.md"))
                {
                    var destinationFile = dataDir + fileName;
                    return GetTextWriterForFile(destinationFile);
                }
            }
            return null;
        }
        private TextWriter GetTextWriterForFile(string relativeFilePath)
        {
            var fullPath = Path.GetFullPath(relativeFilePath);
            TextWriter writer = File.CreateText(fullPath);
            return writer;
        }
    }
}
