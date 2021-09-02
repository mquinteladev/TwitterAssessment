using Interfaces.Model;

namespace BusinessModel.Model
{
    public class StreamDataResponseBo : DataResponseBo, IStreamDataResponseBo
    {
        public IPublicMetricsBo PublicMetrics { get; set; }
    }
}
