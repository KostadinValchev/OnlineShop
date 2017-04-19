using System.Configuration;
using System.Data.Entity;
using Marketplace.Data;
using Microsoft.Owin;
using Marketplace.Data.Migrations;
using Owin;


namespace Marketplace.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var context = new MarketplaceContext();
            //context.Database.Initialize(true);
            ConfigureAuth(app);
        }
    }
}
