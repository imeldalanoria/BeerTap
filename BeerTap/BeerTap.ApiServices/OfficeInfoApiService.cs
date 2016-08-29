using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTap.ApiServices.Security;
using BeerTap.DataPersistance.Repositories;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class OfficeInfoApiService : IOfficeInfoApiService
    {
        readonly IApiUserProvider<BeerTapApiUser> _userProvider;

        private OfficeInfoRepository _repository = null;

        public OfficeInfoApiService(OfficeInfoRepository repository)
        {
            _repository = repository;
        }

        public OfficeInfoApiService(IApiUserProvider<BeerTapApiUser> userProvider)
        {
            if (userProvider == null) throw new ArgumentNullException("userProvider");

            _userProvider = userProvider;
        }

        public Task<OfficeInfo> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            int officeId = ServiceHelper.GetUrlParameters<Office>(context, "OfficeId");
            int officeInfoId = ServiceHelper.GetUrlParameters<OfficeInfo>(context, "Id");
            var query = AutoMapper.Mapper.Map<OfficeInfo>(_repository.GetDataByOfficeInfoId(officeId, officeInfoId));
            return Task.FromResult(query);
        }

        public Task<IEnumerable<OfficeInfo>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            int officeId = ServiceHelper.GetUrlParameters<Office>(context, "OfficeId");
            var query = _repository.GetDataByOfficeId(officeId).Select(o => AutoMapper.Mapper.Map<OfficeInfo>(o));
            return Task.FromResult(query);
        }
    }
}
