using System;
using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class IndexConstituentSourceFactory
    {
        private IDictionary<string, Type> _sourceClasses;
        internal IndexConstituentSourceFactory()
        {
            _sourceClasses = new Helper().GetAllSourceClasses();
        }
        internal IIndexConstituentSource GetEquityIndexSource(string equityIndex)
        {
            if (equityIndex == null || !_sourceClasses.ContainsKey(equityIndex)) throw new ArgumentException(nameof(equityIndex) + " value is incorrect.");
            var sourceType = _sourceClasses[equityIndex];
            var constructor = sourceType.GetConstructor(Type.EmptyTypes);
            var instance = (IIndexConstituentSource)constructor.Invoke(new object[] { });
            return instance;
        }
    }
}
