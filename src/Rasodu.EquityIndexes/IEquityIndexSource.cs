﻿using System.Collections.Generic;

namespace Rasodu.EquityIndexes
{
    interface IEquityIndexSource
    {
        List<Equity> GetAllEquities();
    }
}
