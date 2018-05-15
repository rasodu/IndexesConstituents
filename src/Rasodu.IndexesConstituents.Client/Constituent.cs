using System;
using Newtonsoft.Json;

namespace Rasodu.IndexesConstituents.Client
{
    public class Constituent : IComparable<Constituent>, IEquatable<Constituent>
    {
        [JsonRequired]
        public string StockExchange;
        [JsonRequired]
        public string Identifier;
        public int CompareTo(Constituent other)
        {
            var diff = StockExchange.CompareTo(other.StockExchange);
            if (diff == 0)
            {
                diff = Identifier.CompareTo(other.Identifier);
            }
            return diff;
        }
        public bool Equals(Constituent other)
        {
            return CompareTo(other) == 0;
        }
    }
}
