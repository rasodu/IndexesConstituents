﻿using System;

namespace Rasodu.EquityIndexes
{
    class Program
    {
        static void Main(string[] args)
        {
            var updater = new Updater();
            updater.UpdateAll();
        }
    }
}
