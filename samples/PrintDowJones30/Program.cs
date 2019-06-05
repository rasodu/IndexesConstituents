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
        static async Task PrintConstituents()
        {
            var constituents = await GetConstituents();
            foreach (var constituent in constituents)
            {
                Console.WriteLine($"Stock = {constituent.StockExchange}:{constituent.Identifier}");
            }
        }
        static async Task<IEnumerable<Constituent>> GetConstituents()
        {
            var client = new IndexesConstituentsClient();
            return await client.GetConstituents(Index.DowJones30);
        }
    }
}
