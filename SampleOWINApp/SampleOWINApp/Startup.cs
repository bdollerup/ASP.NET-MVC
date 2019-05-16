using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;

[assembly: OwinStartup(typeof(SampleOWINApp.Startup))]

namespace SampleOWINApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType =
                       CookieAuthenticationDefaults.AuthenticationType
                });
            app.UseWsFederationAuthentication(
                new WsFederationAuthenticationOptions
                {
                    MetadataAddress = "https://login.gribskov.dk/FederationMetadata/2007-06/FederationMetadata.xml",
                    Wtrealm = "https://localhost:44303/",
                });

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}
