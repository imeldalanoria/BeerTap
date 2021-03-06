﻿using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({Id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }
        public override IResourceStateSpec<Office, NullState, int> StateSpec
        {
            get
            {

                return new SingleStateSpec<Office, int>
                {
                    Links =
                    {
                        CreateLinkTemplate(LinkRelations.OfficeInfo, OfficeInfoSpec.Uri.Many, c => c.Id)
                    },
                    Operations =
                    {
                        Get = ServiceOperations.Get
                    }

                };
            }
        }


    }
}