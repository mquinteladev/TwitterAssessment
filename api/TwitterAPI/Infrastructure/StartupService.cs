using System;
using System.Threading;
using System.Threading.Tasks;
using Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TwitterAPI.HubConfig;

namespace TwitterAPI.Infrastructure
{
    public class StartupService : IHostedService
    {
        private readonly IServiceProvider _services;
        public StartupService(IServiceProvider services)
        {
            _services = services;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _services.CreateScope();
            var twitterUnitOfWork = scope.ServiceProvider.GetService<ITwitterUnitOfWork>();
            IHubContext<ChartHub> hub = scope.ServiceProvider.GetService<IHubContext<ChartHub>>();
            ThreadWork.Init(hub, twitterUnitOfWork);
            Thread thread = new Thread(() =>
            {
                ThreadWork.DoWork();
            });
            thread.Start();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
