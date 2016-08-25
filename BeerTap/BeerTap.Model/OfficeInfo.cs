using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{

    public class OfficeInfo : IStatefulResource<OfficeInfoState>, IIdentifiable<int>, IStatefulOfficeInfo
    {
        public int Id { get; set; }

        public int OfficeId { get; set; }

        public string Beertype { get; set; }

        public decimal Milliliter { get; set; }

        public OfficeInfoState OfficeInfoState
        {
            get
            {
                if (this.Milliliter >= 2365)
                {
                    return OfficeInfoState.New;
                }
                else if (this.Milliliter < 2365 && this.Milliliter > 946)
                {
                    return OfficeInfoState.GoinDown;
                }
                else if (this.Milliliter <= 946 && this.Milliliter > 0)
                {
                    return OfficeInfoState.AlmostEmpty;
                }
                else
                {
                    return OfficeInfoState.SheIsDryMate;
                }
            }
        }
    }
}
