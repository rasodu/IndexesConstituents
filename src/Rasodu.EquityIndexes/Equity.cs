using System;

namespace Rasodu.EquityIndexes
{
    internal class Equity : IComparable<Equity>, IEquatable<Equity>
    {
        internal string StockExchange = null;
        internal string Identifier = null;
        public int CompareTo(Equity other)
        {
            var compareVal = StockExchange.CompareTo(other.StockExchange);
            if (compareVal == 0)
            {
                compareVal = Identifier.CompareTo(other.Identifier);
            }
            return compareVal;
        }
        public bool Equals(Equity other)
        {
            return
                StockExchange == other.StockExchange
                && Identifier == other.Identifier;
        }
    }
}