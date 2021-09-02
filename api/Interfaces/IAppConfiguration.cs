namespace Interfaces
{
    public interface IAppConfiguration
    {
        string ApiKey { get; }
        string ApiKeySecret { get; }
        string ApiUrl { get; }
        object BearerToken { get; }
    }
}