using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public interface IReplaceKegApiService :
        ICreateAResourceAsync<ReplaceKeg, int>
    {
    }
}
