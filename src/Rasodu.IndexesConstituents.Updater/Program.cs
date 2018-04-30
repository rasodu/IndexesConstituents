using System;

namespace Rasodu.IndexesConstituents.Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            var updater = new IndexesConstituentsUpdater();
            updater.UpdateAll();
        }
    }
}
