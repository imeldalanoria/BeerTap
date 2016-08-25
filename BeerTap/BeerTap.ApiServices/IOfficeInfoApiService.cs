using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public interface IOfficeInfoApiService :
        IGetAResourceAsync<OfficeInfo, int>,
        IGetManyOfAResourceAsync<OfficeInfo, int>
    {
    }
}
