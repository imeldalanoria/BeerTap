using System.Collections.Generic;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class OfficeInfoSpec : ResourceSpec<OfficeInfo, OfficeInfoState, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/OfficeInfos({Id})");
        public override string EntrypointRelation
        {
            get { return LinkRelations.OfficeInfo; }
        }

        protected override IEnumerable<ResourceLinkTemplate<OfficeInfo>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId, c => c.Id);
        }
        protected override IEnumerable<IResourceStateSpec<OfficeInfo, OfficeInfoState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<OfficeInfo, OfficeInfoState, int>(OfficeInfoState.New)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.OfficeInfos.Tap, TapSpec.Uri, c=>c.OfficeId, c=> c.Id)
                },
                Operations = new StateSpecOperationsSource<OfficeInfo, int>()
                {
                    Post = ServiceOperations.Update
                }
            };
            yield return new ResourceStateSpec<OfficeInfo, OfficeInfoState, int>(OfficeInfoState.GoinDown)
            {
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.OfficeInfos.Tap, TapSpec.Uri, x => x.OfficeId, c => c.Id)
                    },
                Operations = new StateSpecOperationsSource<OfficeInfo, int>()
                {
                    Post = ServiceOperations.Update
                }
            };

            yield return new ResourceStateSpec<OfficeInfo, OfficeInfoState, int>(OfficeInfoState.AlmostEmpty)
            {
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.OfficeInfos.Tap, TapSpec.Uri, x => x.OfficeId, c => c.Id),
                        CreateLinkTemplate(LinkRelations.OfficeInfos.ReplaceKeg, ReplaceKegSpec.Uri, x => x.OfficeId, c => c.Id)
                    },
                Operations = new StateSpecOperationsSource<OfficeInfo, int>()
                {
                    Post = ServiceOperations.Update
                }
            };

            yield return new ResourceStateSpec<OfficeInfo, OfficeInfoState, int>(OfficeInfoState.SheIsDryMate)
            {
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.OfficeInfos.ReplaceKeg, ReplaceKegSpec.Uri, x => x.OfficeId, c => c.Id)
                    },
                Operations = new StateSpecOperationsSource<OfficeInfo, int>()
                {
                    InitialPost = ServiceOperations.Create
                }
            };

        }

    }
}