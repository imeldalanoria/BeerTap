﻿using System;
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
    public class OfficeApiService : IOfficeApiService
    {
        private OfficeRepository _repository = null;

        public OfficeApiService(OfficeRepository repository)
        {
            _repository = repository;
        }

        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var query = _repository.Get(id);
            return Task.FromResult(AutoMapper.Mapper.Map<Office>(query));

        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)

        {
            var query = _repository.Get().Select(o => AutoMapper.Mapper.Map<Office>(o));
            return Task.FromResult(query);
        }
            
    }
}
