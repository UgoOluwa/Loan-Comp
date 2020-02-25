using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Loan_Comp.Startup))]
namespace Loan_Comp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
