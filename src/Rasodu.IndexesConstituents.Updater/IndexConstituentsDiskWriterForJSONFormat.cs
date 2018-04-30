using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.IndexesConstituents.Updater
{
    class IndexConstituentsDiskWriterForJSONFormat : IIndexConstituentsDiskWriter
    {
        private TextWriter _destination;
        internal IndexConstituentsDiskWriterForJSONFormat(TextWriter destination)
        {
            _destination = destination;
            _destination.NewLine = "\n";
        }
        public void ReplaceAll(List<Equity> equities)
        {
            var jsonWriter = new JsonTextWriter(_destination);
            jsonWriter.Formatting = Formatting.Indented;
            var jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(jsonWriter, equities);
            jsonWriter.Flush();
        }
    }
}