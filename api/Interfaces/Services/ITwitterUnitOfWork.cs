using System;
using System.Threading.Tasks;
using Interfaces.Model;

namespace Interfaces.Services
{
    public interface ITwitterUnitOfWork
    {
        event EventHandler<IStreamDataResponseBo> StreamTweetProcessed;
        Task ProcessTwitterStreamAsync();
    }
}
