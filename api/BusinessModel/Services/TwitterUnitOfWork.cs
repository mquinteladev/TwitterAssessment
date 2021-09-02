using System;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessModel.Constants;
using BusinessModel.Extensions;
using Domain.Model.ApiModel;
using Interfaces;
using Interfaces.Model;
using Interfaces.Services;

namespace BusinessModel.Services
{
    public class TwitterUnitOfWork : ITwitterUnitOfWork
    {
        private readonly ICache _cache;
        private readonly ITwitterApiFacade _twitterApiFacade;

        void HandleCustomEvent(object sender, string data)
        {
            TwitterStreamResponse response = JsonSerializer.Deserialize<TwitterStreamResponse>(data);
            var tweetBo = response.AsStreamDataResponse();
            if (tweetBo != null)
            {
                var cacheKey = $"{CacheConstants.TWEET}{tweetBo.Id}";
                _cache.Set(cacheKey, tweetBo);
                OnStreamTweetProcessed(tweetBo);
                Console.WriteLine(data);
            }
        }

        public TwitterUnitOfWork(ICache cache, ITwitterApiFacade twitterApiFacade)
        {
            _cache = cache;
            _twitterApiFacade = twitterApiFacade;
            _twitterApiFacade.StreamRead += HandleCustomEvent;
        }

        public event EventHandler<IStreamDataResponseBo> StreamTweetProcessed;

        public async Task ProcessTwitterStreamAsync() => await _twitterApiFacade.GetSearchStream();

        protected virtual void OnStreamTweetProcessed(IStreamDataResponseBo e) => StreamTweetProcessed?.Invoke(this, e);
    }
}
