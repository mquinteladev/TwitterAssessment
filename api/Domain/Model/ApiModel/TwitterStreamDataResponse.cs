namespace Domain.Model.ApiModel
{
    public class TwitterStreamDataResponse
    {
        public string id { get; set; }
        public TwitterPublicMetrics public_metrics { get; set; }
        public string text { get; set; }
    }
}
