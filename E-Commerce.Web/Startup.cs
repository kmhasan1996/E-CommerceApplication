using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Commerce.Web.Startup))]
namespace E_Commerce.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
