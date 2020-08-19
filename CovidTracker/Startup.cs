using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CovidTracker.Startup))]
namespace CovidTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
