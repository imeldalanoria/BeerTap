using System.Threading;
using System.Threading.Tasks;
using BeerTap.DAL;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class ReplaceKegApiService : IReplaceKegApiService
    {
        private OfficeInfoRepository _repository = null;
        public ReplaceKegApiService(OfficeInfoRepository repository)
        {
            _repository = repository;
        }

        public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            int officeId = ServiceHelper.GetUrlParameters<Office>(context, "OfficeId");
            int officeInfoId = ServiceHelper.GetUrlParameters<OfficeInfo>(context, "OfficeInfoId");

            var oldKeg = _repository.Get(officeInfoId);

            oldKeg.Milliliter = oldKeg.Milliliter + resource.Milliliter;
            oldKeg.Beertype = resource.Beertype ?? oldKeg.Beertype;

            _repository.Update(oldKeg);
            _repository.SaveChanges();

            context.LinkParameters.Set(new LinksParametersSource(officeId, officeInfoId));
            return Task.FromResult(new ResourceCreationResult<ReplaceKeg, int>(resource)); 
        }
    }
}
