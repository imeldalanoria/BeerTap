using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.ApiServices.Security;
using BeerTap.DataPersistance.Repositories;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTap.ApiServices
{
    public class TapApiService : ITapApiService
    {
        private OfficeInfoRepository _repository = null;

        public TapApiService(OfficeInfoRepository repository)
        {
            _repository = repository;
        }

        public Task<ResourceCreationResult<Tap, int>> CreateAsync(Tap resource, IRequestContext context, CancellationToken cancellation)
        {
            int officeId = ServiceHelper.GetUrlParameters<Office>(context, "OfficeId");
            int officeInfoId = ServiceHelper.GetUrlParameters<OfficeInfo>(context, "OfficeInfoId");
            var kegId = _repository.Get(officeInfoId);

            decimal tapMilliliter = resource.Milliliter;
            decimal remainingMilliliter = kegId.Milliliter;

            if (kegId.Milliliter <= 0)
                throw context.CreateHttpResponseException<Tap>("This keg is empty", HttpStatusCode.BadRequest);

            if (tapMilliliter > remainingMilliliter)
                kegId.Milliliter = 0;
            else
                kegId.Milliliter = remainingMilliliter - tapMilliliter;

            _repository.Update(kegId);
            _repository.SaveChanges();

            context.LinkParameters.Set(new LinksParametersSource(officeId, officeInfoId));
            return Task.FromResult(new ResourceCreationResult<Tap, int>(resource));

        }
    }
}
