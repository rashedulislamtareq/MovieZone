using MovieZone.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace MovieZone
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //For Auto mapper Dtos 
            Mapper.Initialize(x=>x.AddProfile<MappingProfile>());

            //To Enable web api service
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
