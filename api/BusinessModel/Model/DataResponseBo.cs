using Interfaces.Model;

namespace BusinessModel.Model
{
    public class DataResponseBo: IDataResponseBo
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
