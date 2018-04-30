using System;
using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class IndexConstituentsSourceFactory
    {
        private IDictionary<string, Type> _sourceClasses;
        internal IndexConstituentsSourceFactory()
        {
            _sourceClasses = new Helper().GetAllSourceClasses();
        }
        internal IIndexConstituentsSource GetEquityIndexSource(string equityIndex)
        {
            if (equityIndex == null || !_sourceClasses.ContainsKey(equityIndex)) throw new ArgumentException(nameof(equityIndex) + " value is incorrect.");
            var sourceType = _sourceClasses[equityIndex];
            var constructor = sourceType.GetConstructor(Type.EmptyTypes);
            var instance = (IIndexConstituentsSource)constructor.Invoke(new object[] { });
            return instance;
        }
    }
}
