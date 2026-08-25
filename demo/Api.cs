var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOutputCache();

var app = builder.Build();
app.MapDefaultEndpoints();
app.MapGet("/", () => Results.Ok(new { service = "api", status = "ready" }));
app.Run();