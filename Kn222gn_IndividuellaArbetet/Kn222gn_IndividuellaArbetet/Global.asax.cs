using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using Kn222gn_IndividuellaArbetet.App_Start;

namespace Kn222gn_IndividuellaArbetet
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Routeconfig.RegisterRoutes(RouteTable.Routes);
        }

    }
}