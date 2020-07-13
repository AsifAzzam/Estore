using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalEstore.cs.Startup))]
namespace PersonalEstore.cs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
