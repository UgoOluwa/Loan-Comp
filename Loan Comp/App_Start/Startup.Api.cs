using Microsoft.Owin;
using Owin;

//[assembly: OwinStartup(typeof(Api.Startup))]

namespace Loan_Comp
{
    public partial class Startup
    {
        public void ConfigurationApi(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
