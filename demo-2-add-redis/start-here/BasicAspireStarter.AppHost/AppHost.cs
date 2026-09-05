var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.BasicAspireStarter_Api>("api")
	.WithHttpHealthCheck("/health")
	.WithExternalHttpEndpoints();

builder.AddProject<Projects.BasicAspireStarter_Web>("web")
	.WithReference(api)
	.WaitFor(api)
	.WithExternalHttpEndpoints();

builder.Build().Run();
