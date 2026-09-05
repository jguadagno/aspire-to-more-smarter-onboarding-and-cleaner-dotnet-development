var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("redis")
	.WithDbGate();

var api = builder.AddProject<Projects.BasicAspireStarter_Api>("api")
	.WithReference(cache)
	.WaitFor(cache)
	.WithHttpHealthCheck("/health")
	.WithExternalHttpEndpoints();

builder.AddProject<Projects.BasicAspireStarter_Web>("web")
	.WithReference(cache)
	.WaitFor(cache)
	.WithReference(api)
	.WaitFor(api)
	.WithExternalHttpEndpoints();

builder.Build().Run();
