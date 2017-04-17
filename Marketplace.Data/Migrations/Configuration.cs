namespace Marketplace.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Marketplace.Data.MarketplaceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
<<<<<<< HEAD
            ContextKey = "Marketplace.Data.MarketplaceContext";
=======
>>>>>>> e97130b19e5617d6ae9dfe5db7377f0bfd246b6d
        }

        protected override void Seed(Marketplace.Data.MarketplaceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
