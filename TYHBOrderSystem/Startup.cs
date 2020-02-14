using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TYHBOrderSystem.Startup))]
namespace TYHBOrderSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
