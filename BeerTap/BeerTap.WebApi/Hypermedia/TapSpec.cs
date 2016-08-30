using System.Collections.Generic;
using BeerTap.ApiServices;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class TapSpec : SingleStateResourceSpec<Tap, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/OfficeInfos({OfficeInfoId})/Taps");

        protected override IEnumerable<ResourceLinkTemplate<Tap>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.OfficeInfoId, x => x.Parameters.OfficeId);
        }
        public override IResourceStateSpec<Tap, NullState, int> StateSpec
        {
            get
            {

                return new SingleStateSpec<Tap, int>
                {
                    Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.OfficeInfo, OfficeInfoSpec.Uri, i => i.Parameters.OfficeId, i => i.Parameters.OfficeInfoId)
                    },
                    Operations =
                    {
                        InitialPost = ServiceOperations.Create
                    }

                };
            }
        }

    }

}