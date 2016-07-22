using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CursoWeb.Startup))]
namespace CursoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
