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
            HttpConfiguration config = new HttpConfiguration();

            ODataConfig.Register(config);

            WebApiConfig.Register(config);

            app.UseWebApi(config);

            ConfigureAuth(app);
        }
    }
}
