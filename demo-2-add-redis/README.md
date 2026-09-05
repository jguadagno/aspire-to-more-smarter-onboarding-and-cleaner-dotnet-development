# Add Aspire to an existing ASP.NET Core Web App

This folder contains the completed version of the basic Aspire demo. Aspire starts the API and ASP.NET Core Web App together, shows both resources in the dashboard, and waits for the API before starting the web project.

This is a copy of the demo-1-add-aspire-basic project. It starts with the *complete* version ([demo-1-add-aspire-basic/complete](../demo-1-add-aspire-basic/complete)) and adds Redis to the project.

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

Make a copy of the `start-here` folder, then run these commands in the new folder to add Redis to the project:

```powershell


