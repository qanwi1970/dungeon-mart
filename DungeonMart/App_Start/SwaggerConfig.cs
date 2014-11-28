using System.Web.Http;
using DungeonMart;
using Swashbuckle.Application;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace DungeonMart
{
    internal class SwaggerConfig
    {
        public static void Register()
        {
            Swashbuckle.Bootstrapper.Init(GlobalConfiguration.Configuration);

            // NOTE: If you want to customize the generated swagger or UI, use SwaggerSpecConfig and/or SwaggerUiConfig here ...
            SwaggerSpecConfig.Customize(
                c => c.IncludeXmlComments(System.AppDomain.CurrentDomain.BaseDirectory + @"\bin\DungeonMart.XML"));
        }
    }
}