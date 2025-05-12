var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.FinanceManager_ApiService>("apiservice");

builder.AddProject<Projects.FinanceManager_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
