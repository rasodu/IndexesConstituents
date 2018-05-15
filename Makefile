PHONY =

PHONY += libpacknuget
libpacknuget:
	cd src/Rasodu.IndexesConstituents.Client && dotnet pack -c Release

PHONY += libpushnuget
libpushnuget:
	#modify api and version number then run this target or goto nuget.org and upload the release file there
	cd src/Rasodu.IndexesConstituents.Client/bin/Release && dotnet nuget push Rasodu.IndexesConstituents.Client.1.0.0.nupkg -k <nuget-api-key> -s https://api.nuget.org/v3/index.json

.PHONY: $(PHONY)