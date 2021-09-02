using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.Services
{
    [TestClass()]
    public class TwitterApiFacadeTests : IntegrationTestsBase
    {
        [TestMethod()]
        public void GetSearchStreamTest()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            var task = Task.Run(() =>
            {
                var twitter = ServiceProvider.GetService<ITwitterApiFacade>();
                twitter.GetSearchStream();
            }, token);
            Func<Task> f = async () => { task.Wait(10000,token); };
            f.Should().NotThrowAsync("Running as expected");
        }

        [TestMethod()]
        public void GetTwitterDetailTest()
        {
            var twitter = ServiceProvider.GetService<ITwitterApiFacade>();
            var result = twitter.GetTwitterDetail("1433178388597022720");
            result.Should().NotBeNull();
            result.Id.Should().Equals(result.Id);
        }
    }
}