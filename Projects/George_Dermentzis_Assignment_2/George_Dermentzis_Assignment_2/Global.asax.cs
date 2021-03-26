using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using George_Dermentzis_Assignment_2.App_Start;

namespace George_Dermentzis_Assignment_2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Mapper.Initialize(m => m.AddProfile<OrganizationProfile>());
#pragma warning restore CS0618 // Type or member is obsolete

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}