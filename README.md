# packages.Api.Responses
Easy to use responses template including template for paged results.

The response template includes ProblemDetails human-readable property based on [rfc7807](https://datatracker.ietf.org/doc/html/rfc7807) 

[Note to self]

I can push nuget package to Github without nuget.config or PAT/tokens/passwords in-code or in configs (where [PAT] the Github PAT with write:packages permissions)
    
    dotnet nuget push packages.Api.Responses.0.0.3.nupkg --source https://nuget.pkg.github.com/lostinmyworld/index.json --api-key [PAT]

To add my Github packages as VS package source run the following (where [READ_PAT] is a Github PAT with read:packages permissions)
    
    dotnet nuget add source "https://nuget.pkg.github.com/lostinmyworld/index.json" -n "Github Packages" --username lostinmyworld --password [READ_PAT] --store-password-in-clear-text