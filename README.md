# [C# Client](https://www.nuget.org/packages/Rasodu.IndexesConstituents.Client/)

You can use our C# client to read index constituents in your project.
```
async static Task<IEnumerable<Constituent>> GetConstituents()
{
    var client = new IndexesConstituentsClient();
    return await client.GetConstituents(StockExchange.DowJones30);
}
```

# Indexes Updater

This project aggregates indexes information from various sources. Updated data is stored in 'Data' directory. Data is collected from following source.

| Equity Index | Source |
| --- | --- |
| Dow Jones 30 | https://en.wikipedia.org/wiki/Dow_Jones_Industrial_Average |
| S&P 500 | https://en.wikipedia.org/wiki/List_of_S%26P_500_companies |
| Nasdaq 100 | https://www.nasdaq.com/quotes/nasdaq-100-stocks.aspx |
| Nifty 100 | https://www.nseindia.com/products/content/equities/indices/nifty_100.htm |

# FAQ

### Where can I find data?
List of stocks are available in CSV and JSON format. Files are in "Data" subdirectory of the repository. If you are C# developer, then you can use our C Sharp client to pull information.

### Index I am looking for is not available...
You can add scanner for the index and create a pull request. We will be happy to accept your contribution. However you must follow two guidelines listed below:
1. You must pull data from an official source.
1. Source data must be in well know format(CSV,JSON,...).

### I think data is out of date...
We try our best to keep the data up to date. If you think data is not up to date, then run the scanner and create pull request.