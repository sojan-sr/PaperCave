using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaperCave.Infrastructure.Clients;
using PaperCave.Infrastructure.Data;
using PaperCave.Infrastructure.Utils;
using PaperCave.Models.Settings;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<IBookRepository, BookRepository>();
        services.AddSingleton<FeedIteratorUtil>();
        services.AddSingleton<ICosmosClientBuilder, CosmosClientBuilder>();
        services.AddOptions<CosmosSettings>()
            .Configure<IConfiguration>((settings, configuration) => 
            {
                configuration.GetSection("CosmosSettings").Bind(settings);
            });
    })
    .Build();

await host.RunAsync();
