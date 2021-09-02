using System;
using BusinessModel.Services;
using Domain;
using Interfaces;
using Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests
{
    public class IntegrationTestsBase
    {
        protected readonly IServiceCollection Services;
        protected readonly IServiceProvider ServiceProvider;

        protected IntegrationTestsBase()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var cache = new MemoryCache(new MemoryCacheOptions());
            Services = new ServiceCollection();
            Services.AddSingleton<IMemoryCache>(cache);
            Services.AddSingleton<IConfiguration>(config);
            Services.AddScoped<ITwitterUnitOfWork, TwitterUnitOfWork>();
            Services.AddScoped<ICache, Domain.Storage.MemoryCache>();
            Services.AddScoped<IAppConfiguration, AppConfiguration>();
            Services.AddScoped<ITwitterApiFacade, TwitterApiFacade>();
            ServiceProvider = Services.BuildServiceProvider();
        } 
    }
}
