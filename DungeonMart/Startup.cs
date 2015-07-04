using log4net;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DungeonMart.Startup))]
namespace DungeonMart
{
    public partial class Startup
    {
	    private static readonly ILog _logger = LogManager.GetLogger(typeof (Startup));

        public void Configuration(IAppBuilder app)
        {
			_logger.Debug("Starting application");
            ConfigureAuth(app);
        }
    }
}
