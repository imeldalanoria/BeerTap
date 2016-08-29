using System.Data.Entity;
using System.Web.Http;
using BeerTap.DataPersistance;
using BeerTap.WebApi.Infrastructure;

namespace BeerTap.WebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<BeerTapDbContext>(null);
            BootStrapper.Initialize(GlobalConfiguration.Configuration);
            AutoMapperConfig.RegisterMappings();
        }
    }
}