using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public interface ITapApiService :
        ICreateAResourceAsync<Tap, int>
    {
    }
}
