using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSocketsWebHmi.Startup))]
namespace WebSocketsWebHmi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
