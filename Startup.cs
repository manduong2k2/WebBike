using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBike.Startup))]
namespace WebBike
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
