using System.Collections.Generic;
using BeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class OfficeInfoStateProvider : OfficeInfoStateProvider<OfficeInfo>
    {
    }

    public abstract class OfficeInfoStateProvider<TOfficeInfoResource> :
        ResourceStateProviderBase<TOfficeInfoResource, OfficeInfoState>
        where TOfficeInfoResource : IStatefulResource<OfficeInfoState>, IStatefulOfficeInfo
    {
        public override OfficeInfoState GetFor(TOfficeInfoResource resource)
        {
            return resource.OfficeInfoState;
        }

        protected override IDictionary<OfficeInfoState, IEnumerable<OfficeInfoState>> GetTransitions()
        {
            return new Dictionary<OfficeInfoState, IEnumerable<OfficeInfoState>>
        {
            {
                OfficeInfoState.New, new[]
                {
                    OfficeInfoState.GoinDown
                }
            },
            {
                OfficeInfoState.GoinDown, new []
                {
                    OfficeInfoState.AlmostEmpty
                }
            },
            {
                OfficeInfoState.AlmostEmpty, new []
                {
                    OfficeInfoState.SheIsDryMate
                }
            }
        };
        }
        public override IEnumerable<OfficeInfoState> All
        {
            get { return EnumEx.GetValuesFor<OfficeInfoState>(); }
        }

    }
}