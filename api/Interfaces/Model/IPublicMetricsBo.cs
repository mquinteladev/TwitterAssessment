namespace Interfaces.Model
{
    public interface IPublicMetricsBo
    {
        int RetweetCount { get; set; }
        int ReplyCount { get; set; }
        int LikeCount { get; set; }
        int QuoteCount { get; set; }
    }
}