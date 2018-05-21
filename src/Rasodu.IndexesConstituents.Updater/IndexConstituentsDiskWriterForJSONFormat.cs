using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.IndexesConstituents.Updater
{
    class IndexConstituentsDiskWriterForJSONFormat : IIndexConstituentsDiskWriter
    {
        private TextWriter _destination;
        public IndexConstituentsDiskWriterForJSONFormat(TextWriter destination)
        {
            _destination = destination;
        }
        public string FileExtension()
        {
            return "json";
        }
        public void ReplaceAll(List<Equity> equities)
        {
            _destination.NewLine = "\n";
            var jsonWriter = new JsonTextWriter(_destination);
            jsonWriter.Formatting = Formatting.Indented;
            var jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(jsonWriter, equities);
            jsonWriter.Flush();
        }
    }
}