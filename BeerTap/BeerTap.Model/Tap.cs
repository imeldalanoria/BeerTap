using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    public class Tap : IStatelessResource, IIdentifiable<int>
    {
        public int Id { get; set; }

        public decimal Milliliter { get; set; }
    }
}
