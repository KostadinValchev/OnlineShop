using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Marketplace.Models;

namespace Marketplace.Data
{
    public class MarketplaceContext : IdentityDbContext<ApplicationUser>
    {
        public MarketplaceContext()
            : base("MarketplaceContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MarketplaceContext, Configuration>());
        }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public virtual IDbSet<Review> Review { get; set; }

        public static MarketplaceContext Create()
        {
            return new MarketplaceContext();
        }
    }
}
