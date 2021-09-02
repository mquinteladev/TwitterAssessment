using System;
using System.Threading.Tasks;
using Interfaces.Model;

namespace Interfaces.Services
{
    public interface ITwitterApiFacade
    {
        event EventHandler<string> StreamRead;
        Task GetSearchStream();
        IDataResponseBo GetTwitterDetail(string id);
    }
}
