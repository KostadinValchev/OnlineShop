using System;
using System.Collections.Generic;
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

        public static MarketplaceContext Create()
        {
            return new MarketplaceContext();
        }
    }
}
