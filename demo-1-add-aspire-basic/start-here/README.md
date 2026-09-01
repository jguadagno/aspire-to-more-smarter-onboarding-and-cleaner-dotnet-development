# Basic Aspire Starter

This folder contains the starter application for the basic Aspire demo. It intentionally starts as two independently run projects so the demo can add Aspire orchestration later.

## Projects

- `BasicAspireStarter.Api`: ASP.NET Core minimal API that exposes `GET /weatherforecast`.
- `BasicAspireStarter.Web`: ASP.NET Core Web App that calls the API and renders the response with Razor Pages.

## Run locally

Open two terminals from this folder:

```powershell
dotnet run --project .\BasicAspireStarter.Api\BasicAspireStarter.Api.csproj --launch-profile http
```

```powershell
dotnet run --project .\BasicAspireStarter.Web\BasicAspireStarter.Web.csproj --launch-profile http
```

Then open the web app at `http://localhost:5005`.
