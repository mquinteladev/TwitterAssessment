using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessModel.Extensions;
using Domain.Model.ApiModel;
using Interfaces;
using Interfaces.Model;
using Interfaces.Services;
using RestSharp;

namespace BusinessModel.Services
{
    public class TwitterApiFacade: ITwitterApiFacade
    {
        private readonly IAppConfiguration _appConfiguration;

        public event EventHandler<string> StreamRead;

        public TwitterApiFacade(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task GetSearchStream()
        {
            try
            {
                //Connect
                var webRequest = (HttpWebRequest) WebRequest.Create($"{_appConfiguration.ApiUrl}/2/tweets/sample/stream?tweet.fields=public_metrics");
                webRequest.Timeout = 60000;
                webRequest.Headers.Add("Authorization", $"Bearer {_appConfiguration.BearerToken}");
                var encode = Encoding.GetEncoding("utf-8");
                webRequest.Method = "GET";
                var webResponse = (HttpWebResponse) webRequest.GetResponse();
                var responseStream = new StreamReader(webResponse.GetResponseStream(), encode);

                //Read the stream.
                while (true)
                {
                    try
                    {
                        var jsonText = responseStream.ReadLine();
                        OnStreamRead(jsonText);
                    }
                    catch (Exception ex)
                    {
                    }
                    
                }

                //Abort is needed or responseStream.Close() will hang.
                webRequest.Abort();
                responseStream.Close();
                responseStream = null;
                webResponse.Close();
                webResponse = null;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IDataResponseBo GetTwitterDetail(string id)
        {
            var client =
                new RestClient(
                    $"{_appConfiguration.ApiUrl}/2/tweets/{id}?tweet.fields=&expansions=&media.fields=&place.fields=&poll.fields=&user.fields=")
                {
                    Timeout = -1
                };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {_appConfiguration.BearerToken}");
            IRestResponse response = client.Execute(request);
            var outputResponse = JsonSerializer.Deserialize<TwitterResponse>(response.Content);
            IDataResponseBo output = outputResponse.AsDataResponse();
            return output;
        }
        
        protected virtual void OnStreamRead(string e)
        {
            StreamRead?.Invoke(this, e);
        }
    }
}
