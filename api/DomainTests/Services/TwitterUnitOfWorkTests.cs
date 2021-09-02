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
    public class TwitterUnitOfWorkTests : IntegrationTestsBase
    {
        [TestMethod()]
        public void ProcessTwitterStreamTest()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            var task = Task.Run(() =>
            {
                var twitterUnitOfWork = ServiceProvider.GetService<ITwitterUnitOfWork>();
                twitterUnitOfWork.Should().NotBeNull();
                twitterUnitOfWork.ProcessTwitterStreamAsync();
            }, token);
            Func<Task> f = async () => { task.Wait(10000, token); };
            f.Should().NotThrowAsync("Running as expected");
        }
    }
}