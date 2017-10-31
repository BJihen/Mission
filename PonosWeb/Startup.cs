using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PonosWeb.Startup))]
namespace PonosWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
