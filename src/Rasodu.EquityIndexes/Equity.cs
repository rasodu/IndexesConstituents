﻿using System;

namespace Rasodu.EquityIndexes
{
    public class Equity : IComparable<Equity>, IEquatable<Equity>
    {
        public string StockExchange { get; set; }
        public string Identifier { get; set; }
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