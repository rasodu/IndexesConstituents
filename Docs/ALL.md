# Architecture

### Projects
- **Scanner** : This project implement scanners that help keep index constituent data up to date.
    - Will read data from sources and save it to appropriate files
    - Will write data to various formats
    - The updated files then manually gets committed to repository
- **Client** : Developer will use client in their program to pull constituent information.
    - Read data file committed to repository
    - Provide C# developer developer an easy way to access the data

### Scanner sources
This project aggregates indexes information from various sources. Updated data is stored in 'Data' directory. Data is collected from following source.

| Equity Index | Source |
| --- | --- |
| Dow Jones 30 | https://en.wikipedia.org/wiki/Dow_Jones_Industrial_Average |
| S&P 500 | https://en.wikipedia.org/wiki/List_of_S%26P_500_companies |
| Nasdaq 100 | https://www.nasdaq.com/quotes/nasdaq-100-stocks.aspx |
| Nifty 100 | https://www.nseindia.com/products/content/equities/indices/nifty_100.htm |


# Contributing

### Tools
- [Git](https://git-scm.com/downloads)
- Install all SDKs listed on [.NET SDK page](https://dotnet.microsoft.com/download/visual-studio-sdks?utm_source=getdotnetsdk&utm_medium=referral) - All SDKs are required because old runtimes are not bundled with all SDKs. Installing all SDKs will allow you to build apps for any version of .NET Core. ~[SDK 2.1.101](https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0.6.md) : We have pinned SDK version for the software and runtime version in Xunit projects~
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) ~or [VS Code](https://code.visualstudio.com/download)~

### Development flow
- Open Github issue to start discussion for the change and assign the issue to Github project
- Create pull request containing the change
