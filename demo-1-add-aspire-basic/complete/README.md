# Basic Aspire Complete

This folder contains the completed version of the basic Aspire demo. Aspire starts the API and ASP.NET Core Web App together, shows both resources in the dashboard, and waits for the API before starting the web project.

## Projects

- `BasicAspireStarter.Api`: ASP.NET Core minimal API that exposes `GET /weatherforecast`.
- `BasicAspireStarter.Web`: ASP.NET Core Web App that calls the API and renders the response with Razor Pages.
- `BasicAspireStarter.AppHost`: Aspire AppHost that orchestrates the API and web projects.
- `BasicAspireStarter.ServiceDefaults`: shared Aspire defaults for health checks, service discovery, resilience, and telemetry.

## Run with Aspire

From this folder, start the whole app with Aspire:

```powershell
aspire start --non-interactive
```

Open the web endpoint from the Aspire dashboard.

## Steps used to create this completed version

Start from the `start-here` folder, then run these commands from this folder after copying the starter app into `complete`:

```powershell
aspire init --language csharp --non-interactive
dotnet new aspire-servicedefaults --name BasicAspireStarter.ServiceDefaults
dotnet sln .\BasicAspireStarter.slnx add .\BasicAspireStarter.AppHost\BasicAspireStarter.AppHost.csproj .\BasicAspireStarter.ServiceDefaults\BasicAspireStarter.ServiceDefaults.csproj
dotnet add .\BasicAspireStarter.AppHost\BasicAspireStarter.AppHost.csproj reference .\BasicAspireStarter.Api\BasicAspireStarter.Api.csproj .\BasicAspireStarter.Web\BasicAspireStarter.Web.csproj
dotnet add .\BasicAspireStarter.Api\BasicAspireStarter.Api.csproj reference .\BasicAspireStarter.ServiceDefaults\BasicAspireStarter.ServiceDefaults.csproj
```

Then update `BasicAspireStarter.AppHost/AppHost.cs` to model the application:

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.BasicAspireStarter_Api>("api")
	.WithHttpHealthCheck("/health")
	.WithExternalHttpEndpoints();

builder.AddProject<Projects.BasicAspireStarter_Web>("web")
	.WithReference(api)
	.WaitFor(api)
	.WithExternalHttpEndpoints();

builder.Build().Run();
```

Finally, update the API to call `builder.AddServiceDefaults()` and `app.MapDefaultEndpoints()` so Aspire gets health checks and telemetry for the resource. Update the web project to use `builder.AddServiceDefaults()` and configure its API `HttpClient` with `https+http://api` so Aspire service discovery resolves the API endpoint at runtime.
