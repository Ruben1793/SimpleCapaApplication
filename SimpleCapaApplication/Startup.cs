using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleCapaApplication.Startup))]
namespace SimpleCapaApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
