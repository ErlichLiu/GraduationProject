using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DayUp.Startup))]
namespace DayUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
