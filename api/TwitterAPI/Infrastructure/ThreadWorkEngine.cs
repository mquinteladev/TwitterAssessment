using System;
using Interfaces.Model;
using Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using TwitterAPI.HubConfig;

namespace TwitterAPI.Infrastructure
{
    public class ThreadWork
    {
        private static IHubContext<ChartHub> _hub;
        private static ITwitterUnitOfWork _twitterUnitOfWork;

        public static void Init(IHubContext<ChartHub> hub, ITwitterUnitOfWork twitterUnitOfWork)
        {
            _hub = hub;
            _twitterUnitOfWork = twitterUnitOfWork;
        }

        public static void DoWork( )
        {
            _twitterUnitOfWork.StreamTweetProcessed += HandleCustomEvent;
            _twitterUnitOfWork.ProcessTwitterStreamAsync();
        }

        static void HandleCustomEvent(object sender, IStreamDataResponseBo data)
        {
            _hub?.Clients.All.SendAsync("transferchartdata", data);
            Console.WriteLine(data);
        }
    }
}