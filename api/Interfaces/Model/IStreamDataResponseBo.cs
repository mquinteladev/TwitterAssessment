namespace Interfaces.Model
{
    public interface IStreamDataResponseBo
    {
        string Id { get; set; }
        IPublicMetricsBo PublicMetrics { get; set; }
        string Text { get; set; }
    }
}