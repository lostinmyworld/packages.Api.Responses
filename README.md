# packages.Api.Responses
Easy to use responses template including template for paged results.

The response template includes ProblemDetails human-readable property based on [rfc7807](https://datatracker.ietf.org/doc/html/rfc7807) 

[Note to self]
I can push nuget package to Github without nuget.config or PAT/tokens/passwords in-code or in configs (where [PAT] the Personal Access Token with write:packages in repo)
    dotnet nuget push packages.Api.Responses.0.0.3.nupkg --source https://nuget.pkg.github.com/lostinmyworld/index.json --api-key [PAT]
