using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NorthWind.Api.Startup))]

namespace NorthWind.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //app.UseWebApi(config);

            ConfigureAuth(app);
        }
    }
}
