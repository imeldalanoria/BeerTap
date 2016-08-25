using System.Net;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class ServiceHelper
    {
        public static int GetUrlParameters<T>(IRequestContext context, string paramName) where T : class
        {
            return context.UriParameters.GetByName<int>(paramName).EnsureValue(() =>
            context.CreateHttpResponseException<T>(string.Format("The {0} must be supplied in the URI",paramName), HttpStatusCode.BadRequest)); ;
        }

    }
}
