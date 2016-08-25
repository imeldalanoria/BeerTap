using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    public class Office : IStatelessResource, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string OfficeName { get; set; }
        
    }
}
