using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartyNeighbors.MVC.Startup))]
namespace PartyNeighbors.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
