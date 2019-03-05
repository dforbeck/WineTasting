using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WineTasting.WebMVC.Startup))]
namespace WineTasting.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
