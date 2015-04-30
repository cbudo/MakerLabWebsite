using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoseMakerSpace.Startup))]
namespace RoseMakerSpace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
