using Rasodu.IndexesConstituents.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintDowJones30
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintConstituents().GetAwaiter().GetResult();
        }
        async static Task PrintConstituents()
        {
            var constituents = await GetConstituents();
            foreach (var constituent in constituents)
            {
                Console.WriteLine($"Stock = {constituent.StockExchange}:{constituent.Identifier}");
            }
        }
        async static Task<IEnumerable<Constituent>> GetConstituents()
        {
            var client = new IndexesConstituentsClient();
            return await client.GetConstituents(Index.DowJones30);
        }
    }
}
