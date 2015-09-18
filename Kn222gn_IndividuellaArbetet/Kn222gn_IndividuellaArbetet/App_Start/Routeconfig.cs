using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Kn222gn_IndividuellaArbetet.App_Start
{
    public class Routeconfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("BesokareSida", "", "~/Pages/Shared/BesokareSida.aspx");
            routes.MapPageRoute("Information", "Information", "~/Pages/Shared/Information.aspx");
            routes.MapPageRoute("PrivilegieSida", "PrivilegieSida", "~/Pages/Shared/PrivilegieSida.aspx");
        }
    }
}