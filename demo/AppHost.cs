var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var api = builder.AddProject<Projects.Api>("api")
    .WithReference(cache)
    .WaitFor(cache);

builder.AddProject<Projects.Web>("web")
    .WithReference(api)
    .WaitFor(api);

builder.Build().Run();