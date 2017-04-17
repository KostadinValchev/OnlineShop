using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Marketplace.Models;

namespace Marketplace.Data
{
    public class MarketplaceContext : IdentityDbContext<ApplicationUser>
    {
        public MarketplaceContext()
            : base("MarketplaceContext", throwIfV1Schema: false)
        {
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
