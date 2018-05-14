using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rasodu.IndexesConstituents.Client
{
    internal class ConstituentParser
    {
        internal IEnumerable<Constituent> ParseConstituent(string json)
        {
            IEnumerable<Constituent> result;
            try
            {
                result = JsonConvert.DeserializeObject<IEnumerable<Constituent>>(json);
            }
            catch (Exception e)
            {
                throw new IndexConstituentClientException("Problem while parsing JSON string", e);
            }
            return result;
        }
    }
}