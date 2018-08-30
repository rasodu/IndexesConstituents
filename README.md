# Goals

- Provide a way for developers to get constituents for well known indexes.
- The data should contain both stock exchange and ticker for the constituents.
- If the constituents list gets updated by index maintainer, then call to the same API should return updated data.


# User manual

### C# Client - [Install via nuget.org](https://www.nuget.org/packages/Rasodu.IndexesConstituents.Client/)

You can use our C# client to read index constituents in your project.
```
async static Task<IEnumerable<Constituent>> GetConstituents()
{
    var client = new IndexesConstituentsClient();
    return await client.GetConstituents(Index.DowJones30);
}
```

### FAQ

#### I am not using C# or I need to access to raw data...
If you are C# developer, then you can use our C Sharp client to pull constituents in an Index. However, lists are also available in CSV and JSON format. Files are in "Data" subdirectory of the repository.

#### Index I am looking for is not available...
You can add scanner for the index and create a pull request. We will be happy to accept your contribution. However you must follow two guidelines listed below:
1. You must pull data from an official source.
1. Source data must be in well know format(CSV,JSON,...).

#### I think data is outdated...
We try our best to keep the data up to date. If you think data is not up to date, then run the scanner and create pull request with updated data files.
