using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DungeonMart.Startup))]
namespace DungeonMart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
